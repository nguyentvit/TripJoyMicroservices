namespace Authentication.API.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken) : ICommand<RefreshTokenResult>;
    public record RefreshTokenResult(UserLogin UserLogin);
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh Token is not empty");
        }
    }
    internal class RefreshTokenCommandHandler
        (IConfiguration configuration)
        : ICommandHandler<RefreshTokenCommand, RefreshTokenResult>
    {
        public async Task<RefreshTokenResult> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
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
                    new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", command.RefreshToken)
                })
            };

            var tokenResponse = await client.SendAsync(token);
            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new InvalidCredentialsAuthenticationException();
            }

            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var userLogin = JsonConvert.DeserializeObject<UserLogin>(tokenContent);

            return new RefreshTokenResult(userLogin!);
        }
    }
}
