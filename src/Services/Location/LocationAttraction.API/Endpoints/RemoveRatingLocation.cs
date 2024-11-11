using LocationAttraction.Application.Locations.Commands.RemoveRating;

namespace LocationAttraction.API.Endpoints
{
    public record RemoveRatingLocationResponse(bool IsSuccess);
    public class RemoveRatingLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/location/rate/{locationId}", async (string locationId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt().ToString();

                var command = new RemoveRatingCommand(locationId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<RemoveRatingLocationResponse>();

                return Results.Ok(response);
            })
            .WithName("RemoveRatingLocation")
            .Produces<RemoveRatingLocationResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Remove Rating Location")
            .WithDescription("Remove Rating Location");
        }
    }
}
