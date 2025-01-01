namespace PostManagement.Application.Posts.Commands.LikePost
{
    public record LikePostCommand(LikePostDto LikePost, Guid UserId, Guid PostId) : ICommand<LikePostResult>;
    public record LikePostResult(bool IsSuccess);
    public class LikePostCommandValidator : AbstractValidator<LikePostCommand>
    {
        public LikePostCommandValidator()
        {
            RuleFor(command => command.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.");

            RuleFor(command => command.LikePost.Emotion)
                .IsInEnum().WithMessage("Emotion must be a valid enum value.");

            RuleFor(command => command.UserId)
                .NotNull().WithMessage("UserId must not be null");
        }
    }
}
