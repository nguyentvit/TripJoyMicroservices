
namespace PostManagement.Application.Comments.Commands.RevokeLikeComment
{
    public class RevokeLikeCommentHandler
        (IApplicationDbContext dbContext) : ICommandHandler<RevokeLikeCommentCommand, RevokeLikeCommentResult>
    {
        public async Task<RevokeLikeCommentResult> Handle(RevokeLikeCommentCommand command, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(command.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var userId = UserId.Of(command.UserId);
            comment.RemoveCommentReactionByUserId(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RevokeLikeCommentResult(true);
        }
    }
}
