namespace LocationAttraction.Application.Locations.Commands.AddImage
{
    public class AddImageHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<AddImageCommand, AddImageResult>
    {
        public async Task<AddImageResult> Handle(AddImageCommand command, CancellationToken cancellationToken)
        {
            var locationId = LocationId.Of(Guid.Parse(command.Image.LocationId));
            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);
            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            var image = Image.Of(command.Image.Url);
            location.AddImage(image);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddImageResult(true);
        }
    }
}
