
namespace PostManagement.Application.Posts.Commands.CommentPost
{
    public class CommentPostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<CommentPostCommand, CommentPostResult>
    {
        public async Task<CommentPostResult> Handle(CommentPostCommand command, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(command.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);

            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(command.UserId);
            var content = Content.Of(command.Comment.Content);

            var comment = Comment.CreateComment(userId, post, content);

            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CommentPostResult(comment.Id.Value);
        }
    }
}
