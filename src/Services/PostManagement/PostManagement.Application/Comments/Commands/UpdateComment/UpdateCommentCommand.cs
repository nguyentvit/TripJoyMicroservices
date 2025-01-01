namespace PostManagement.Application.Comments.Commands.UpdateComment
{
    public record UpdateCommentCommand(Guid CommentId, Guid UserId, UpdateCommentDto UpdatedComment) : ICommand<UpdateCommentResult>;
    public record UpdateCommentResult(bool IsSuccess);
}
