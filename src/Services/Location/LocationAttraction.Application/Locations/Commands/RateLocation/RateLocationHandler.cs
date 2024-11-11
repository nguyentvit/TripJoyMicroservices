namespace LocationAttraction.Application.Locations.Commands.RateLocation
{
    public class RateLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RateLocationCommand, RateLocationResult>
    {
        public async Task<RateLocationResult> Handle(RateLocationCommand command, CancellationToken cancellationToken)
        {
            var locationId = LocationId.Of(Guid.Parse(command.Rating.LocationId));
            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);
            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            var userId = UserId.Of(Guid.Parse(command.Rating.UserId));
            var rating = Rating.Of(userId, command.Rating.Value);

            location.RateLocation(rating);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new RateLocationResult(true);
        }
    }
}
