
namespace PostManagement.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentHandler
        (IApplicationDbContext dbContext) : ICommandHandler<UpdateCommentCommand, UpdateCommentResult>
    {
        public async Task<UpdateCommentResult> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(command.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var userId = UserId.Of(command.UserId);
            if (comment.UserId != userId)
                throw new Exception("You don't have permission to change this comment");

            var content = Content.Of(command.UpdatedComment.Content);
            comment.UpdateComment(content);
            dbContext.Comments.Update(comment);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateCommentResult(true);
        }
    }
}
