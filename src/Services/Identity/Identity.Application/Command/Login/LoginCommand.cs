namespace Identity.Application.Command.Login
{
    public record LoginResult(
        string AccessToken,
        string RefreshToken,
        int ExpiresIn,
        string TokenType,
        string IdToken,
        LoginUserResult User
        );
    public record LoginUserResult(
        string Id,
        string UserName,
        string Email,
        string Name
        );
    public record LoginCommand(string Email, string Password) : IRequest<ErrorOr<LoginResult>>;
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
