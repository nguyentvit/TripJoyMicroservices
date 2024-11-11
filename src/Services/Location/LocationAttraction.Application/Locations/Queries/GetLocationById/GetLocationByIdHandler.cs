namespace LocationAttraction.Application.Locations.Queries.GetLocationById
{
    public class GetLocationByIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetLocationByIdQuery, GetLocationByIdResult>
    {
        public async Task<GetLocationByIdResult> Handle(GetLocationByIdQuery query, CancellationToken cancellationToken)
        {
            var locationId = LocationId.Of(Guid.Parse(query.LocationId));
            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);
            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            var locationResponseDtp = await location.ToLocationResponseDto(dbContext);
            return new GetLocationByIdResult(locationResponseDtp);

        }
    }
}
