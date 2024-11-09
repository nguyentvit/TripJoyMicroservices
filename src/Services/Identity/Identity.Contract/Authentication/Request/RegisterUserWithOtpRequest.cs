namespace Identity.Contract.Authentication.Request
{
    public record RegisterUserWithOtpRequest(string Email, string Name, string Password, string ConfirmPassword, string Otp);
}
