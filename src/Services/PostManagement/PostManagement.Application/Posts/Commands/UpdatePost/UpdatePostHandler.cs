
namespace PostManagement.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<UpdatePostCommand, UpdatePostResult>
    {
        public async Task<UpdatePostResult> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(command.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(command.UserId);
            if (userId != post.UserId)
                throw new Exception("You don't have permission to update post");

            var images = command.UpdatedPost.Images?.Select(FileImg.Of).ToList();
            var content = Content.Of(command.UpdatedPost.Content);

            post.UpdatePost(content, images);
            dbContext.Posts.Update(post);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePostResult(true);

        }
    }
}
