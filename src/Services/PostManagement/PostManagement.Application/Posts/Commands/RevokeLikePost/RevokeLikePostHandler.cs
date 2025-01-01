
namespace PostManagement.Application.Posts.Commands.RevokeLikePost
{
    public class RevokeLikePostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<RevokeLikePostCommand, RevokeLikePostResult>
    {
        public async Task<RevokeLikePostResult> Handle(RevokeLikePostCommand command, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(command.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(command.UserId);
            post.RemovePostReactionByUserId(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RevokeLikePostResult(true);
        }
    }
}
