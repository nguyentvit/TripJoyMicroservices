using LocationAttraction.Application.Locations.Queries.GetLocationByCoordinates;

namespace LocationAttraction.API.Endpoints
{
    public record GetLocationByCoordinatesRequest(double Latitude, double Longitude);
    public record GetLocationByCoordinatesResponse(LocationResponseDto Location);
    public class GetLocationByCoordinates : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/location/coordinates", async ([AsParameters] GetLocationByCoordinatesRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetLocationByCoordinatesQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetLocationByCoordinatesResponse>();

                return Results.Ok(response);
            })
            .WithName("GetLocationByCoordinates")
            .Produces<GetLocationByCoordinatesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Location By Coordinates")
            .WithDescription("Get Location By Coordinates");
        }
    }
}
