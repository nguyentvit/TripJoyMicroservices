using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace UserAccess.Application.Data
{
    public class CachedUserRepository
        (IUserRepository repository,
        IDistributedCache cache)
        : IUserRepository
    {
        public DbSet<User> Users => repository.Users;

        public async Task<User> GetUserById(UserId UserId, CancellationToken cancellationToken = default)
        {
            var cachedUser = await cache.GetStringAsync(UserId.Value.ToString(), cancellationToken);
            if (!string.IsNullOrEmpty(cachedUser))
                return JsonConvert.DeserializeObject<User>(cachedUser)!;

            var user = await repository.GetUserById(UserId, cancellationToken);
            var userJson = JsonConvert.SerializeObject(user);
            await cache.SetStringAsync(UserId.Value.ToString(), userJson, cancellationToken);
            return user;
        }
    }
}
