namespace Identity.Application.Queries.ForgetPassword
{
    public record ForgetPasswordQuery(string Email) : IRequest<ErrorOr<ForgetPasswordResult>>;
}
