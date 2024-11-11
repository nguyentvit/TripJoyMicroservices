namespace LocationAttraction.Application.Locations.Queries.GetImagesByLocationId
{
    public class GetImagesByLocationIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetImagesByLocationIdQuery, GetImagesByLocationIdResult>
    {
        public async Task<GetImagesByLocationIdResult> Handle(GetImagesByLocationIdQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var locationId = LocationId.Of(Guid.Parse(query.LocationId));

            var location = await dbContext.Locations.FindAsync([locationId], cancellationToken);

            if (location == null)
                throw new LocationNotFoundException(locationId.Value);

            var totalCount = location.Images.Count;

            var imagesResponse = location.ToLocationImageResponseDto(pageIndex, pageSize);

            return new GetImagesByLocationIdResult(
                PaginationResponse: new PaginationResponse(pageIndex, pageSize, totalCount),
                Images: imagesResponse
                );
        }
    }
}
