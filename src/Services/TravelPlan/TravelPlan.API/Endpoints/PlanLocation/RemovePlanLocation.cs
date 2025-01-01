
using TravelPlan.Application.PlanLocations.Commands.RemovePlanLocation;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record RemovePlanLocationResponse(bool IsSuccess);
    public class RemovePlanLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/planLocations/{planLocationId}", async (ISender sender, Guid planLocationId, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RemovePlanLocationCommand(userId, planLocationId);

                var result = await sender.Send(command);

                var response = result.Adapt<RemovePlanLocationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
