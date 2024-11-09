namespace Location.Domain.Models
{
    public class Location : Aggregate<LocationId>
    {
        private readonly List<Image> _images = new();
        public IReadOnlyList<Image> Images => _images.AsReadOnly();
        public LocationName Name { get; set; } = default!;
        public Coordinates Coordinates { get; set; } = default!;
    }
}
