namespace UserAccess.Application.Users.Commands.AcceptFriendRequest
{
    public record AcceptFriendRequestCommand(AcceptFriendRequestDto Request) : ICommand<AcceptFriendRequestResult>;
    public record AcceptFriendRequestResult(bool IsSuccess);
    public class AcceptFriendRequestCommandValidator : AbstractValidator<AcceptFriendRequestCommand>
    {
        public AcceptFriendRequestCommandValidator()
        {
            RuleFor(r => r.Request).NotNull().WithMessage("Receiver information cannot be null.");

            RuleFor(r => r.Request.AccountId)
                .NotNull().WithMessage("Unauthorized")
                .NotEmpty().WithMessage("Unauthorized");

            RuleFor(r => r.Request.SenderId)
                .NotEmpty().WithMessage("Sender ID cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Sender ID must be a valid GUID.");
        }
    }
}
