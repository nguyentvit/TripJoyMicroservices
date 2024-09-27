namespace Authentication.API.Login
{
    public record LoginCommand(string Email, string Password) : ICommand<LoginResult>;
    public record LoginResult(UserLogin UserLogin);
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
    internal class LoginCommandHandler
        (IConfiguration configuration)
        : ICommandHandler<LoginCommand, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var ipAuthentication = configuration.GetValue<string>("IpServerAuthentication");

            var token = new HttpRequestMessage(HttpMethod.Post, $"{ipAuthentication}/connect/token")
            {
                Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", command.Email),
                    new KeyValuePair<string, string>("password", command.Password),
                    new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("scope", "email openid profile offline_access")
                })
            };

            var tokenResponse = await client.SendAsync(token);

            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new InvalidCredentialsAuthenticationException();
            }

            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var userLogin = JsonConvert.DeserializeObject<UserLogin>(tokenContent);


            return new LoginResult(userLogin!);
        }
    }
}
