using LocationAttraction.Application.Locations.Queries.GetLocationById;

namespace LocationAttraction.API.Endpoints
{
    public record GetLocationByIdResponse(LocationResponseDto Location);
    public class GetLocationById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/location/{locationId}", async (string locationId, ISender sender) =>
            {
                var query = new GetLocationByIdQuery(locationId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetLocationByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetLocationById")
            .Produces<GetLocationByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Location By Id")
            .WithDescription("Get Location By Id");
        }
    }
}
