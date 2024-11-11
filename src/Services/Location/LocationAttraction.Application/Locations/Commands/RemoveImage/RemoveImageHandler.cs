namespace LocationAttraction.Application.Locations.Commands.RemoveImage
{
    public class RemoveImageHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemoveImageCommand, RemoveImageResult>
    {
        public async Task<RemoveImageResult> Handle(RemoveImageCommand request, CancellationToken cancellationToken)
        {
            var locationId = LocationId.Of(Guid.Parse(request.LocationId));
            var imageId = ImageId.Of(Guid.Parse(request.ImageId));

            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);
            if (location == null) 
                throw new LocationNotFoundException(locationId.Value);

            location.RemoveImage(imageId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveImageResult(true);
        }
    }
}
