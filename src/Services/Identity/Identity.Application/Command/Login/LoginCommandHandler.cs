using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Identity.Application.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<ErrorOr<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
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
            var token = new HttpRequestMessage(HttpMethod.Post, $"{url}connect/token")
            {
                Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", request.Email),
                    new KeyValuePair<string, string>("password", request.Password),
                    new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("scope", "email openid profile offline_access")
                })
            };
            var tokenResponse = await client.SendAsync(token);
            if (!tokenResponse.IsSuccessStatusCode)
            {
                var errorContent = await tokenResponse.Content.ReadAsStringAsync();
                return Errors.Authentication.InvalidCredentials;
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<TokenResult>(tokenContent);

            
            LoginUserResult loginUserResult = new(user.UserId, user.UserName, user.Email, user.Name, user.Id);
            LoginResult loginResult = new(tokenResult.AccessToken, tokenResult.RefreshToken, tokenResult.ExpiresIn, tokenResult.TokenType, tokenResult.IdToken, loginUserResult);

            return loginResult;
        }
    }
}
