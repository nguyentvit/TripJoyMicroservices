namespace Location.Grpc.Models
{
    public class LocationRating
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public double Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public double AverageRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Location Location { get; set; } = default!;
    }
}
