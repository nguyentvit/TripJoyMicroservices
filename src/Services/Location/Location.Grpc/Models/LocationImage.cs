namespace Location.Grpc.Models
{
    public class LocationImage
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Location Location { get; set; } = default!;
    }
}
