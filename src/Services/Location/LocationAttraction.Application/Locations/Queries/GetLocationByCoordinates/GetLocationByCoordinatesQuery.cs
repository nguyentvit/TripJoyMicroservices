namespace LocationAttraction.Application.Locations.Queries.GetLocationByCoordinates
{
    public record GetLocationByCoordinatesQuery(double Latitude, double Longitude) : IQuery<GetLocationByCoordinatesResult>;
    public record GetLocationByCoordinatesResult(LocationResponseDto Location);
}
