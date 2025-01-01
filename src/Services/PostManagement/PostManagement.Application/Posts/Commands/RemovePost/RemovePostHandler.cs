
namespace PostManagement.Application.Posts.Commands.RemovePost
{
    public class RemovePostHandler
        (IApplicationDbContext dbContext,
        IS3Service s3Serivce) : ICommandHandler<RemovePostCommand, RemovePostResult>
    {
        public async Task<RemovePostResult> Handle(RemovePostCommand command, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(command.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(command.UserId);
            if (post.UserId != userId)
                throw new Exception("You don't have permission to remove this post");

            var commentIds = post.CommentIds;

            foreach (var commentId in commentIds)
            {
                await DeleteCommentWithReplies(commentId, cancellationToken);
            }

            var images = post.PostImages.Select(pi => pi.Image.Url).ToList();

            dbContext.Posts.Remove(post);

            await dbContext.SaveChangesAsync(cancellationToken);
            
            foreach (var image in images)
            {
                await s3Serivce.DeleteFileAsync(image);
            }

            return new RemovePostResult(true);
        }
        private async Task DeleteCommentWithReplies(CommentId commentId, CancellationToken cancellationToken = default)
        {
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var childCommentIds = comment.CommentReplyIds.ToList();

            foreach (var childCommentId in childCommentIds)
            {
                await DeleteCommentWithReplies(childCommentId, cancellationToken);
            }

            dbContext.Comments.Remove(comment);
        }
    }
}
