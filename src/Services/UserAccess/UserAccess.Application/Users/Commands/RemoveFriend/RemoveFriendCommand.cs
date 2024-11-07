namespace UserAccess.Application.Users.Commands.RemoveFriend
{
    public record RemoveFriendCommand(RemoveFriendDto Request) : ICommand<RemoveFriendResult>;
    public record RemoveFriendResult(bool IsSuccess);
    public class RemoveFriendCommandValidator : AbstractValidator<RemoveFriendCommand>
    {
        public RemoveFriendCommandValidator()
        {
            RuleFor(r => r.Request).NotNull().WithMessage("Receiver information cannot be null.");

            RuleFor(r => r.Request.UserId)
                .NotNull().WithMessage("Unauthorized")
                .NotEmpty().WithMessage("Unauthorized");

            RuleFor(r => r.Request.FriendId)
                .NotEmpty().WithMessage("Friend ID cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Friend ID must be a valid GUID.");
        }
    }
}
