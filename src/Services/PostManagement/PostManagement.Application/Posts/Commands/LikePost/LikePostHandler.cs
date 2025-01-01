
namespace PostManagement.Application.Posts.Commands.LikePost
{
    public class LikePostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<LikePostCommand, LikePostResult>
    {
        public async Task<LikePostResult> Handle(LikePostCommand command, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(command.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(command.UserId);
            var emotion = command.LikePost.Emotion;
            var postReaction = PostReaction.Of(userId, emotion);

            post.AddPostReaction(postReaction);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new LikePostResult(true);
        }
    }
}
