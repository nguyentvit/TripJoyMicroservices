namespace LocationAttraction.Application.Locations.Queries.GetRatingsByLocationId
{
    public class GetRatingsByLocationIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetRatingsByLocationIdQuery, GetRatingsByLocationIdResult>
    {
        public async Task<GetRatingsByLocationIdResult> Handle(GetRatingsByLocationIdQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var locationId = LocationId.Of(Guid.Parse(query.LocationId));

            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);

            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            var totalCount = location.Ratings.Count;

            var ratingsResponse = location.ToLocationRatingResponseDto(pageIndex, pageSize);

            return new GetRatingsByLocationIdResult(
                PaginationResponse: new PaginationResponse(pageIndex, pageSize, totalCount),
                Ratings: ratingsResponse
                );
        }
    }
}
