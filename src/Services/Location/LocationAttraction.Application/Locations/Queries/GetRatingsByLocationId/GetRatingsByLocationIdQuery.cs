namespace LocationAttraction.Application.Locations.Queries.GetRatingsByLocationId
{
    public record GetRatingsByLocationIdQuery(string LocationId, PaginationRequest PaginationRequest) 
        : IQuery<GetRatingsByLocationIdResult>;
    public record GetRatingsByLocationIdResult(PaginationResponse PaginationResponse, List<LocationRatingResponseDto> Ratings);
}
