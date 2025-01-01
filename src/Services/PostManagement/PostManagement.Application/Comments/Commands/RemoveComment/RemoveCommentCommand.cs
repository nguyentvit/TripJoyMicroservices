namespace PostManagement.Application.Comments.Commands.RemoveComment
{
    public record RemoveCommentCommand(Guid UserId, Guid CommentId) : ICommand<RemoveCommentResult>;
    public record RemoveCommentResult(bool IsSuccess);
}
