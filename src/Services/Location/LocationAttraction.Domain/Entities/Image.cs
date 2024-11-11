namespace LocationAttraction.Domain.Entities
{
    public class Image : Entity<ImageId>
    {
        public string Url { get; } = default!;
        private Image(ImageId id, string url)
        {
            Id = id;
            Url = url;
        }
        [JsonConstructor]
        private Image(string url)
        {
            Url = url;
        }
        private Image() { }
        public static Image Of(string Url)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(Url);
            return new Image(ImageId.Of(Guid.NewGuid()), Url);
        }
    }
}
