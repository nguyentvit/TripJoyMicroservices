namespace LocationAttraction.Application.Locations.Commands.CreateLocation
{
    public class CreateLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<CreateLocationCommand, CreateLocationResult>
    {
        public async Task<CreateLocationResult> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
        {
            var location = CreateNewLocation(command.Location);

            dbContext.Locations.Add(location);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateLocationResult(location.Id.Value.ToString());
        }
        private Location CreateNewLocation(LocationAddDto locationAddDto)
        {
            var newLocation = Location.Of(
                id: LocationId.Of(Guid.NewGuid()),
                name: Name.Of(locationAddDto.Name),
                address: (locationAddDto.Address != string.Empty) ? Address.Of(locationAddDto.Address) : null,
                coordinates: Coordinates.Of(locationAddDto.Latitude, locationAddDto.Longitude),
                averageRating: AverageRating.Of(),
                locationCategoryId: LocationCategoryId.Of(Guid.Parse(locationAddDto.LocationCategoryId))
                );

            return newLocation;
        }
    }
}
