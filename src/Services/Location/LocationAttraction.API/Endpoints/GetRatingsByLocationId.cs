using LocationAttraction.Application.Locations.Queries.GetRatingsByLocationId;

namespace LocationAttraction.API.Endpoints
{
    public record GetRatingsByLocationIdResponse(PaginationResponse PaginationResponse, List<LocationRatingResponseDto> Ratings);
    public class GetRatingsByLocationId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/location/rate/{locationId}", async (string locationId, [AsParameters] PaginationRequest pagination, ISender sender) =>
            {
                var query = new GetRatingsByLocationIdQuery(locationId, pagination);

                var result = await sender.Send(query);

                var response = result.Adapt<GetRatingsByLocationIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetRatingsByLocationId")
            .Produces<GetRatingsByLocationIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Rating By LocationId")
            .WithDescription("Get Rating By LocationId");
        }
    }
}
