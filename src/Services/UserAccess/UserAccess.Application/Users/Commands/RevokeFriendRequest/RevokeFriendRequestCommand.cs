namespace UserAccess.Application.Users.Commands.RevokeFriendRequest
{
    public record RevokeFriendRequestCommand(RevokeFriendRequestDto Request) : ICommand<RevokeFriendRequestResult>;
    public record RevokeFriendRequestResult(bool IsSuccess);
    public class RevokeFriendRequestCommandValidator : AbstractValidator<RevokeFriendRequestCommand>
    {
        public RevokeFriendRequestCommandValidator()
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
