namespace PostManagement.Application.Comments.Commands.RevokeLikeComment
{
    public record RevokeLikeCommentCommand(Guid CommentId, Guid UserId) : ICommand<RevokeLikeCommentResult>;
    public record RevokeLikeCommentResult(bool IsSuccess);
}
