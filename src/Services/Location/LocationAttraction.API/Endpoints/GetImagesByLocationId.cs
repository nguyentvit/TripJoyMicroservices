using LocationAttraction.Application.Locations.Queries.GetImagesByLocationId;

namespace LocationAttraction.API.Endpoints
{
    public record GetImagesByLocationIdResponse(PaginationResponse PaginationResponse, List<LocationImageResponseDto> Images);
    public class GetImagesByLocationId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/location/image/{locationId}", async ([AsParameters] PaginationRequest pagination, string locationId, ISender sender) =>
            {
                var query = new GetImagesByLocationIdQuery(locationId, pagination);

                var result = await sender.Send(query);

                var response = result.Adapt<GetImagesByLocationIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetImagesByLocationId")
            .Produces<GetImagesByLocationIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Images By LocationId")
            .WithDescription("Get Images By LocationId");
        }
    }
}
