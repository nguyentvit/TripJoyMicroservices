
namespace PostManagement.Application.Comments.Commands.RemoveComment
{
    public class RemoveCommentHandler
        (IApplicationDbContext dbContext) : ICommandHandler<RemoveCommentCommand, RemoveCommentResult>
    {
        public async Task<RemoveCommentResult> Handle(RemoveCommentCommand command, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(command.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var post = await dbContext.Posts.FindAsync([comment.PostId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(comment.PostId.Value);

            var userId = UserId.Of(command.UserId);

            if (comment.UserId != userId && post.UserId != userId)
                throw new Exception("You don't have permission to remove this comment");

            await DeleteCommentWithReplies(commentId, post, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveCommentResult(true);


        }
        private async Task DeleteCommentWithReplies(CommentId commentId, Post post, CancellationToken cancellationToken = default)
        {
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);
            
            var childCommentIds = comment.CommentReplyIds.ToList();

            if (comment.ParentCommentId != null)
            {
                var parentComment = await dbContext.Comments.FindAsync([comment.ParentCommentId], cancellationToken);
                if (parentComment == null)
                    throw new CommentNotFoundException(comment.ParentCommentId.Value);
                parentComment.RemoveChildComment(commentId);
            }
            post.RemoveCommentId(commentId);
            dbContext.Comments.Remove(comment);

            foreach (var childCommentId in childCommentIds)
            {
                await DeleteCommentWithReplies(childCommentId, post, cancellationToken);
            }

            
        }
    }
}
