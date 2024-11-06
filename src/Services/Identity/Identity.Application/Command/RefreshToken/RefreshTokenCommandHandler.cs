using Identity.Domain.Common.Errors;
using Microsoft.Extensions.Configuration;

namespace Identity.Application.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ErrorOr<RefreshTokenResult>>
    {
        private readonly IConfiguration _configuration;
        public RefreshTokenCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ErrorOr<RefreshTokenResult>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var url = "";
            var environment = _configuration["ASPNETCORE_ENVIRONMENT"];
            if (environment == "Development")
            {
                url = "http://localhost:5032/";
            }

            else if (environment == "Production")
            {
                var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
                url = $"http://identity.api:{port}/";
            }

            var refreshToken = command.RefreshToken;

            var client = new HttpClient();
            var token = new HttpRequestMessage(HttpMethod.Post, $"{url}connect/token")
            {
                Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                })
            };
            var tokenResponse = await client.SendAsync(token);
            if (!tokenResponse.IsSuccessStatusCode)
            {
                var errorContent = await tokenResponse.Content.ReadAsStringAsync();
                return Errors.Authentication.InvalidCredentials;
            }

            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<TokenResult>(tokenContent);

            RefreshTokenResult result = new(tokenResult!.AccessToken, tokenResult.RefreshToken, tokenResult.ExpiresIn, tokenResult.TokenType, tokenResult.IdToken);

            return result;
        }
    }
}
