namespace PostManagement.Application.Posts.Commands.CreatePost
{
    public class CreatePostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<CreatePostCommand, CreatePostResult>
    {
        public async Task<CreatePostResult> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var post = command.ToPost();

            dbContext.Posts.Add(post);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePostResult(post.Id.Value);
        }
    }
    public static class PostExtension
    {
        public static Post ToPost(this CreatePostCommand command)
        {
            var userId = UserId.Of(command.UserId);

            var postRequest = command.Post;

            var post = Post.CreatePost(
                userId: userId,
                content: Content.Of(postRequest.Content),
                images: postRequest.Images?.Select(FileImg.Of).ToList()
                );

            return post;
        }
    }
}
