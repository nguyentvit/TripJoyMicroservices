namespace PostManagement.Application.Posts.EventHandlers.Domain
{
    public class AddImagesEventHandler
        (IS3Service s3Service) : IDomainEventHandler<AddImagesEvent>
    {
        public async Task Handle(AddImagesEvent notification, CancellationToken cancellationToken)
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
    }
}
