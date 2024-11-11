namespace LocationAttraction.Application.Locations.Queries.GetLocationByCoordinates
{
    public class GetLocationByCoordinatesHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetLocationByCoordinatesQuery, GetLocationByCoordinatesResult>
    {
        public async Task<GetLocationByCoordinatesResult> Handle(GetLocationByCoordinatesQuery request, CancellationToken cancellationToken)
        {
            var coordinates = Coordinates.Of(request.Latitude, request.Longitude);
            var location = await dbContext.Locations.Where(l => l.Coordinates == coordinates).FirstOrDefaultAsync(cancellationToken);
            if (location == null)
                throw new LocationNotFoundException(request.Latitude, request.Longitude);

            var locationResponseDto = await location.ToLocationResponseDto(dbContext);
            return new GetLocationByCoordinatesResult(locationResponseDto);
        }
    }
}
