namespace PostManagement.Domain.Entities
{
    public class PostPlanLocation : Entity<PostPlanLocationId>
    {
        public LocationId LocationId { get; private set; } = default!;
        public Coordinates Coordinates { get; private set; } = default!;
        public Order Order { get; private set; } = default!;
        public Date EstimatedStartDate { get; private set; } = default!;
        public LocationName Name { get; private set; } = default!;
        public LocationAddress Address { get; private set; } = default!;
        private PostPlanLocation() { }
        private PostPlanLocation(PostPlanLocationId id, LocationId locationId, Coordinates coordinates, Order order, Date estimatedStartDate, LocationName name, LocationAddress address)
        {
            Id = id;
            LocationId = locationId;
            Coordinates = coordinates;
            Order = order;
            EstimatedStartDate = estimatedStartDate;
            Name = name;
            Address = address;
        }
        public static PostPlanLocation Of(LocationId locationId, Coordinates coordinates, Order order, Date estimatedStartDate, LocationName name, LocationAddress address)
        {
            return new PostPlanLocation(PostPlanLocationId.Of(Guid.NewGuid()), locationId, coordinates, order, estimatedStartDate, name, address);
        }
    }
}
