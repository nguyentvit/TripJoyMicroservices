namespace LocationAttraction.Application.Locations.Queries.GetImagesByLocationId
{
    public record GetImagesByLocationIdQuery(string LocationId, PaginationRequest PaginationRequest) : IQuery<GetImagesByLocationIdResult>;
    public record GetImagesByLocationIdResult(PaginationResponse PaginationResponse, List<LocationImageResponseDto> Images);
}
