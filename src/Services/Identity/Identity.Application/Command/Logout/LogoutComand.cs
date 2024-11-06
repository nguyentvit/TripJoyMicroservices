namespace Identity.Application.Command.Logout
{
    public record LogoutResult(
        string Status,
        string Message
        );
    public record LogoutCommand(string RefreshToken) : IRequest<ErrorOr<LogoutResult>>;
}
