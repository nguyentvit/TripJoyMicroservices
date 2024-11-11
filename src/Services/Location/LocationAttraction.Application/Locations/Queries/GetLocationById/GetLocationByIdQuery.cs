namespace LocationAttraction.Application.Locations.Queries.GetLocationById
{
    public record GetLocationByIdQuery(string LocationId) : IQuery<GetLocationByIdResult>;
    public record GetLocationByIdResult(LocationResponseDto Location);
}
