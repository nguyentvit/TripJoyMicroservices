namespace Location.Grpc.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public double Latitude { get ; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<LocationImage> Images { get; set; }
        public LocationCategory Category { get; set; }
    }
}
