namespace PostManagement.Application.Posts.Commands.CommentPost
{
    public record CommentPostCommand(Guid UserId, Guid PostId, CommentPostDto Comment) : ICommand<CommentPostResult>;
    public record CommentPostResult(Guid CommentId);
}
