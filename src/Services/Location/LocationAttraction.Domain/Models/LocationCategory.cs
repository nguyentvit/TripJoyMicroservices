namespace LocationAttraction.Domain.Models
{
    public class LocationCategory : Aggregate<LocationCategoryId>
    {
        private readonly List<LocationId> _locationIds = new();
        public IReadOnlyList<LocationId> LocationIds => _locationIds.AsReadOnly();
        public Name Name { get; set; } = default!;
        public Description Description { get; set; } = default!;
        private LocationCategory() { }
        [JsonConstructor]
        private LocationCategory(
            Name name, 
            Description description, 
            List<LocationId> locationIds)
        {
            Name = name;
            Description = description;
            _locationIds = locationIds ?? new List<LocationId>();
        }
        private LocationCategory(
            LocationCategoryId id, 
            Name name, 
            Description description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public static LocationCategory Of(LocationCategoryId id, Name name, Description description)
        {
            var LocationCategory = new LocationCategory(id, name, description);
            return LocationCategory;
        }
        public void AddLocation(LocationId locationId)
        {
            if (_locationIds.Contains(locationId))
                throw new DomainException($"Location with ID {locationId.Value} already exists.");

            _locationIds.Add(locationId);
        }
    }
}
