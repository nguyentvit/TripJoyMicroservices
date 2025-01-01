
namespace PostManagement.Application.Posts.EventHandlers.Domain
{
    public class PostUpdatedEventHandler
        (IS3Service s3Service) : IDomainEventHandler<PostUpdatedEvent>
    {
        public async Task Handle(PostUpdatedEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Images != null)
            {
                var images = notification.Images.Select(img => img.Value).ToList();
                var post = notification.Post;

                foreach (var image in images)
                {
                    string url = await s3Service.UploadFileAsync(image);
                    var img = Image.Of(url);
                    var postImage = PostImage.Of(img);
                    post.AddPostImage(postImage);
                }
            }
            
            foreach (var imageRemoved in notification.RemovedImages)
            {
                await s3Service.DeleteFileAsync(imageRemoved.Image.Url);
            }
        }
    }
}
