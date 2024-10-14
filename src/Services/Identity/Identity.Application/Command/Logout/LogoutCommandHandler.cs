using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Errors;
using Microsoft.Extensions.Configuration;

namespace Identity.Application.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, ErrorOr<LogoutResult>>
    {
        private readonly ITokenBlacklistService _blackList;
        private readonly IConfiguration _configuration;
        public LogoutCommandHandler(ITokenBlacklistService blackList, IConfiguration configuration)
        {
            _blackList = blackList;
            _configuration = configuration;
        }
        public async Task<ErrorOr<LogoutResult>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {

            var accessToken = request.AccessToken;
            var refreshToken = request.RefreshToken;

            var ipAuthentication = _configuration.GetConnectionString("SERVER_IP");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);

            var token = new HttpRequestMessage(HttpMethod.Post, $"{ipAuthentication}connect/revocation")
            {
                Content = new FormUrlEncodedContent(new[]
                {   new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("token", request.RefreshToken),
                    new KeyValuePair<string, string>("token_type_hint", "refresh_token")
                })
            };

            var tokenResponse = await client.SendAsync(token);
            if (!tokenResponse.IsSuccessStatusCode)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var timespan = TimeSpan.FromSeconds(3600);

            await _blackList.SetCacheReponseAsync(accessToken, accessToken, timespan);


            LogoutResult logoutResult = new("success", "Log out success");

            return logoutResult;
        }
    }
}
