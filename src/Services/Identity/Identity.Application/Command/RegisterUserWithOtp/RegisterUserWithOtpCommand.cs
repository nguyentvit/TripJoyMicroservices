namespace Identity.Application.Command.RegisterUserWithOtp
{
    public record RegisterUserWithOtpCommand(string Email, string Name, string Password, string ConfirmPassword, string Otp) : IRequest<ErrorOr<RegisterUserWithOtpResult>>;
}
