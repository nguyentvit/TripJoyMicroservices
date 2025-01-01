namespace PostManagement.Application.Posts.Commands.CreatePost
{
    public record CreatePostCommand(Guid UserId, CreatePostDto Post) : ICommand<CreatePostResult>;
    public record CreatePostResult(Guid PostId);
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.Post)
                .NotNull().WithMessage("Post data is required.");
        }
    }
}
