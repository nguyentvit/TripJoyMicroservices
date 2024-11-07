namespace UserAccess.Application.Users.Commands.DeclineFriendRequest
{
    public record DeclineFriendRequestCommand(DeclineFriendRequestDto Request) : ICommand<DeclineFriendRequestResult>;
    public record DeclineFriendRequestResult(bool IsSuccess);
    public class DeclineFriendRequestCommandValidator : AbstractValidator<DeclineFriendRequestCommand>
    {
        public DeclineFriendRequestCommandValidator()
        {
            RuleFor(r => r.Request).NotNull().WithMessage("Receiver information cannot be null.");

            RuleFor(r => r.Request.UserId)
                .NotNull().WithMessage("Unauthorized")
                .NotEmpty().WithMessage("Unauthorized");

            RuleFor(r => r.Request.SenderId)
                .NotEmpty().WithMessage("Sender ID cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Sender ID must be a valid GUID.");
        }
    }
}
