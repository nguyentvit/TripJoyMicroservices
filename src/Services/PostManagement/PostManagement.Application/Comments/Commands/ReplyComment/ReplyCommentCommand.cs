namespace PostManagement.Application.Comments.Commands.ReplyComment
{
    public record ReplyCommentCommand(ReplyCommentDto Comment, Guid UserId, Guid CommentId) : ICommand<ReplyCommentResult>;
    public record ReplyCommentResult(Guid CommentId);
}
