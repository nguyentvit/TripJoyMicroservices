using Identity.Application.Command.Login;

namespace Identity.Application.Command.LoginGoogle
{
    public record LoginGoogleCommand(string AuthorizationCode) : IRequest<ErrorOr<LoginResult>>;
}
