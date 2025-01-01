namespace PostManagement.Domain.Entities
{
    public class PostImage : Entity<PostImageId>
    {
        public Image Image { get; private set; } = default!;
        private PostImage(PostImageId id, Image image)
        {
            Id = id;
            Image = image;
        }
        public static PostImage Of(Image image)
        {
            ArgumentNullException.ThrowIfNull(image, nameof(image));
            return new PostImage(PostImageId.Of(Guid.NewGuid()), image);
        }
    }
}
