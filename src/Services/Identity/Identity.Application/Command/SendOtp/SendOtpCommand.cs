namespace Identity.Application.Command.SendOtp
{
    public record SendOtpCommand(string Email) : IRequest<ErrorOr<SendOtpResult>>;
}
