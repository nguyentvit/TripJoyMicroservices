namespace Identity.Application.Command.RefreshToken
{
    public record RefreshTokenResult(string AccessToken, string RefreshToken, int ExpiresIn, string TokenType, string IdToken);
    public record RefreshTokenCommand(string RefreshToken) : IRequest<ErrorOr<RefreshTokenResult>>;
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
