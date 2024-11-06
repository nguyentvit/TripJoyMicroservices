namespace UserAccess.Application.Users.Commands.SendFriendRequest
{
    public record SentFriendRequestCommand(SentFriendRequestDto Request) : ICommand<SendFriendRequestResult>;
    public record SendFriendRequestResult(bool IsSuccess);
    public class SentFriendRequestCommandValidator : AbstractValidator<SentFriendRequestCommand>
    {
        public SentFriendRequestCommandValidator()
        {
            RuleFor(r => r.Request).NotNull().WithMessage("Receiver information cannot be null.");

            RuleFor(r => r.Request.ReceiverId)
                .NotEmpty().WithMessage("Receiver ID cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Receiver ID must be a valid GUID.");

            RuleFor(r => r.Request.AccountId)
                .NotNull().WithMessage("Unauthorized")
                .NotEmpty().WithMessage("Unauthorized");
        }
    }
}
