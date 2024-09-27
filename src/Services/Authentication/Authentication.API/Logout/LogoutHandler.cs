namespace Authentication.API.Logout
{
    public record LogoutCommand(string RefreshToken) : ICommand<LogoutResult>;
    public record LogoutResult(string Message);
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token is not null");
        }
    }
    internal class LogoutCommandHandler
        (IConfiguration configuration)
        : ICommandHandler<LogoutCommand, LogoutResult>
    {
        public async Task<LogoutResult> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            var ipAuthentication = configuration.GetValue<string>("IpServerAuthentication");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);

            var token = new HttpRequestMessage(HttpMethod.Post, $"{ipAuthentication}/connect/revocation")
            {
                Content = new FormUrlEncodedContent(new[]
                {   new KeyValuePair<string, string>("client_id", "magic"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("token", command.RefreshToken),
                    new KeyValuePair<string, string>("token_type_hint", "refresh_token")
                })
            };

            var tokenResponse = await client.SendAsync(token);
            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new InvalidCredentialsAuthenticationException();
            }

            return new LogoutResult("Log out success");
        }
    }
}
