using LocationAttraction.Application.Locations.Commands.RateLocation;

namespace LocationAttraction.API.Endpoints
{
    public record RateLocationRequest(string LocationId, double Value);
    public record RateLocationResponse(bool IsSuccess);
    public class RateLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/location/rate", async (RateLocationRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext?.GetUserIdFromJwt().ToString()!;

                var locationRatingDto = new LocationRatingDto(request.LocationId, userId, request.Value);

                var command = new RateLocationCommand(locationRatingDto);

                var result = await sender.Send(command);

                var response = result.Adapt<RateLocationResponse>();
                return Results.Ok(response);
            })
            .WithName("RateLocationRequest")
            .Produces<RateLocationResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Rate Location Request")
            .WithDescription("Rate Location Request");
        }
    }
}
