namespace LocationAttraction.Domain.Models
{
    public class Location : Aggregate<LocationId>
    {
        private readonly List<Image> _images = new();
        private readonly List<Rating> _ratings = new();
        public IReadOnlyList<Image> Images => _images.AsReadOnly();
        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
        public Name Name { get; set; } = default!;
        public Address? Address { get; set; }
        public Coordinates Coordinates { get; set; } = default!;
        public AverageRating AverageRating { get; set; } = default!;
        public LocationCategoryId LocationCategoryId { get; set; } = default!;
        private Location() { }
        [JsonConstructor]
        private Location(
            LocationId id, 
            Name name, 
            Address address, 
            Coordinates coordinates,
            List<Image> images,
            List<Rating> ratings,
            AverageRating averageRating,
            LocationCategoryId locationCategoryId)
        {
            Id = id;
            Name = name;
            Address = address;
            Coordinates = coordinates;
            LocationCategoryId = locationCategoryId;
            AverageRating = averageRating;
            _ratings = ratings ?? new List<Rating>();
            _images = images ?? new List<Image>();
        }
        private Location(
            LocationId id,
            Name name, 
            Address? address, 
            Coordinates coordinates, 
            AverageRating averageRating, 
            LocationCategoryId locationCategoryId)
        {
            Id = id;
            Name = name;
            Address = address;
            Coordinates = coordinates;
            LocationCategoryId = locationCategoryId;
            AverageRating = averageRating;
        }
        public static Location Of(LocationId id, Name name, Address? address, Coordinates coordinates, AverageRating averageRating, LocationCategoryId locationCategoryId)
        {
            var location = new Location(id, name, address, coordinates, averageRating, locationCategoryId);

            location.AddDomainEvent(new LocationCreatedEvent(location));

            return location;
        }
        public void RateLocation(Rating rating)
        {
            var existingRating = _ratings.FirstOrDefault(r => r.UserId == rating.UserId);
            if (existingRating != null)
            {
                AverageRating.UpdateRating(existingRating.Value, rating.Value);
                existingRating.UpdateRating(rating.Value);
            }
            else
            {
                _ratings.Add(rating);
                AverageRating.AddNewRating(rating);
            }
        }
        public void RemoveRatingLocation(UserId userId)
        {
            var existingRating = _ratings.FirstOrDefault(r => r.UserId == userId);
            if (existingRating != null)
            {
                _ratings.Remove(existingRating);
                AverageRating.RemoveRating(existingRating);
            }
        }
        public void AddImage(Image image)
        {
            _images.Add(image);
        }
        public void RemoveImage(ImageId imageId)
        {
            var image = _images.FirstOrDefault(i => i.Id == imageId);
            if (image != null)
            {
                _images.Remove(image);
            }
            
        }
    }
}
