using Identity.Application.Command.Login;
using Identity.Domain.Common.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Identity.Application.Command.LoginGoogle
{
    public class LoginGoogleCommandHandler : IRequestHandler<LoginGoogleCommand, ErrorOr<LoginResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public LoginGoogleCommandHandler(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<ErrorOr<LoginResult>> Handle(LoginGoogleCommand request, CancellationToken cancellationToken)
        {
            var authorizationCode = request.AuthorizationCode;

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
                        new KeyValuePair<string, string>("grant_type", OidcConstants.GrantTypes.TokenExchange),
                        new KeyValuePair<string, string>("subject_token", authorizationCode),
                        new KeyValuePair<string, string>("subject_token_type", OidcConstants.TokenTypeIdentifiers.AccessToken),
                        new KeyValuePair<string, string>("client_id", "magic"),
                        new KeyValuePair<string, string>("client_secret", "secret"),
                        new KeyValuePair<string, string>("scope", "email openid profile offline_access")
                    })
            };

            var tokenResponse = await client.SendAsync(token);

            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var handler = new JwtSecurityTokenHandler();
            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<TokenResult>(tokenContent);
            var jwtToken = handler.ReadJwtToken(tokenResult!.AccessToken);
            var claims = jwtToken.Claims;

            var subId = claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
            var user = await _userManager.FindByIdAsync(subId);

            var userId = user.UserId;
            var accountId = user.Id;

            LoginUserResult loginUserResult = new(userId, user.UserName, user.Email, user.Name, accountId);
            LoginResult loginResult = new(tokenResult.AccessToken, tokenResult.RefreshToken, tokenResult.ExpiresIn, tokenResult.TokenType, tokenResult.IdToken, loginUserResult);

            return loginResult;
        }
    }
}
