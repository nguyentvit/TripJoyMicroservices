namespace LocationAttraction.Application.Locations.Commands.RemoveRating
{
    public class RemoveRatingHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemoveRatingCommand, RemoveRatingResult>
    {
        public async Task<RemoveRatingResult> Handle(RemoveRatingCommand request, CancellationToken cancellationToken)
        {
            var locationId = LocationId.Of(Guid.Parse(request.LocationId));
            var userId = UserId.Of(Guid.Parse(request.UserId));

            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);
            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            location.RemoveRatingLocation(userId);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new RemoveRatingResult(true);
        }
    }
}
