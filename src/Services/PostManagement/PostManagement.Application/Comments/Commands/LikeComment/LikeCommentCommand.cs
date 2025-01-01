namespace PostManagement.Application.Comments.Commands.LikeComment
{
    public record LikeCommentCommand(LikeCommentDto LikeComment, Guid UserId, Guid CommentId) : ICommand<LikeCommentResult>;
    public record LikeCommentResult(bool IsSuccess);
}
