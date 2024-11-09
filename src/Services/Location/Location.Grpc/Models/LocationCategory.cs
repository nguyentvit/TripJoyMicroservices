namespace Location.Grpc.Models
{
    public class LocationCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<Location> Locations { get; set; }
    }
}
