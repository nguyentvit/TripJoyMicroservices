
namespace PostManagement.Application.Comments.Commands.LikeComment
{
    public class LikeCommentHandler
        (IApplicationDbContext dbContext) : ICommandHandler<LikeCommentCommand, LikeCommentResult>
    {
        public async Task<LikeCommentResult> Handle(LikeCommentCommand command, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(command.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var userId = UserId.Of(command.UserId);
            var emotion = command.LikeComment.Emotion;
            var commentReaction = CommentReaction.Of(userId, emotion);

            comment.AddCommentReaction(commentReaction);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new LikeCommentResult(true);
        }
    }
}
