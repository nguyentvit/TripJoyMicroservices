using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Errors;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Identity.Application.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, ErrorOr<LogoutResult>>
    {
        private readonly IConfiguration _configuration;
        public LogoutCommandHandler(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task<ErrorOr<LogoutResult>> Handle(LogoutCommand request, CancellationToken cancellationToken)
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
            var client = new HttpClient();

            var token = new HttpRequestMessage(HttpMethod.Post, $"{url}connect/revocation")
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

            LogoutResult logoutResult = new("success", "Log out success");

            return logoutResult;
        }
    }
}
