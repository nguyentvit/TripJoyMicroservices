namespace Identity.Infrastructure.Services
{
    public class RedisTokenWhitelistService : ITokenWhitelistService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IServer _server;
        private readonly IRefreshTokenHasher _refreshTokenHasher;
        private readonly IConfiguration _configuration;
        public RedisTokenWhitelistService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer, IRefreshTokenHasher refreshTokenHasher, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;
            _refreshTokenHasher = refreshTokenHasher;
            _configuration=configuration;

            var connectionString = _configuration.GetConnectionString("Redis");
            var host = connectionString!.Split(":")[0];
            var port = connectionString!.Split(":")[1];
            if (!_connectionMultiplexer.IsConnected)
            {
                throw new Exception("Could not connect to Redis.");
            }

            _server = _connectionMultiplexer.GetServer(host, port);
            
        }
        public async Task SetCacheReponseAsync(string userId, string accessToken, object response, TimeSpan timeOut)
        {
            if (response == null)
                return;

            var cacheKey = $"WhiteList:{userId}:{accessToken}";

            var serializerReponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            await _distributedCache.SetStringAsync(cacheKey, serializerReponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeOut
            });
        }
        public async Task<List<AccessTokenAndUserId>> GetKeysByRefreshTokenAsync(string refreshToken)
        {
            var keys = _server.Keys(pattern: "WhiteList:*").ToList();
            var matchingKeys = new List<AccessTokenAndUserId>();

            foreach (var key in keys)
            {
                var cacheValue = await _distributedCache.GetStringAsync(key);
                if (cacheValue != null)
                {
                    var response = JsonConvert.DeserializeObject<JObject>(cacheValue);

                    var token = response["refreshToken"]?.ToString();


                    if (token == refreshToken)
                    {
                        var accessToken = response["accessToken"]?.ToString();
                        var userId = response["userId"]?.ToString();
                        matchingKeys.Add(new AccessTokenAndUserId(accessToken, userId));
                    }
                }
            }

            return matchingKeys;
        }

        public async Task<List<KeyWhiteList>> GetAllKeysByUserId(string userId)
        {
            var keys = _server.Keys(pattern: $"WhiteList:{userId}:*").ToList();
            var matchingKeys = new List<KeyWhiteList>();

            foreach (var key in keys)
            {
                var cacheValue = await _distributedCache.GetStringAsync(key);
                if (cacheValue != null)
                {
                    var response = JsonConvert.DeserializeObject<JObject>(cacheValue);

                    var refreshToken = response["refreshToken"]?.ToString();
                    var accessToken = response["accessToken"]?.ToString();

                    matchingKeys.Add(new KeyWhiteList(accessToken, userId, refreshToken));
                }
            }

            return matchingKeys;
        }

        public async Task<KeyWhiteList> GetKeyByUserIdAndAccessToken(string userId, string accessToken)
        {
            var cache = $"WhiteList:{userId}:{accessToken}";
            var cacheValue = await _distributedCache.GetStringAsync(cache);

            if (cacheValue != null)
            {
                var response = JsonConvert.DeserializeObject<JObject>(cacheValue);

                var refreshToken = response["refreshToken"]?.ToString();

                return new KeyWhiteList(accessToken, userId, refreshToken);
            }

            return null;
        }

        public async Task<List<AccessTokenAndUserId>> GetKeysByRefreshTokenHashedAsync(string refreshTokenHashed)
        {
            var keys = _server.Keys(pattern: "WhiteList:*").ToList();
            var matchingKeys = new List<AccessTokenAndUserId>();

            foreach (var key in keys)
            {
                var cacheValue = await _distributedCache.GetStringAsync(key);
                if (cacheValue != null)
                {
                    var response = JsonConvert.DeserializeObject<JObject>(cacheValue);

                    var token = response["refreshToken"]?.ToString();


                    if (_refreshTokenHasher.sha256_hash(token) == refreshTokenHashed)
                    {
                        var accessToken = response["accessToken"]?.ToString();
                        var userId = response["userId"]?.ToString();
                        matchingKeys.Add(new AccessTokenAndUserId(accessToken, userId));
                    }
                }
            }

            return matchingKeys;
        }
    }
}
