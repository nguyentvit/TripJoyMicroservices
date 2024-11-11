namespace LocationAttraction.Application.Locations.EventHandlers.Domains
{
    public class LocationCreatedEventHandler
        (IApplicationDbContext dbContext)
        : IDomainEventHandler<LocationCreatedEvent>
    {
        public async Task Handle(LocationCreatedEvent notification, CancellationToken cancellationToken)
        {
            var locationCategoryId = notification.Location.LocationCategoryId;
            var locationCategory = await dbContext.LocationCategories.FindAsync([locationCategoryId], cancellationToken);

            if (locationCategory == null) 
                throw new LocationCategoryNotFoundException(locationCategoryId.Value);

            locationCategory.AddLocation(notification.Location.Id);
        }
    }
}
