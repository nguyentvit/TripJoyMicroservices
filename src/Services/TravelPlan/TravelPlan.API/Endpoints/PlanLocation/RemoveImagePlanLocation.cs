
using TravelPlan.Application.PlanLocations.Commands.RemoveImagePlanLocation;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record RemoveImagePlanLocationResponse(bool IsSuccess);
    public class RemoveImagePlanLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/planLocations/{planLocationId}/images/remove/{imageUrl}", async (IHttpContextAccessor httpContext, ISender sender, Guid planLocationId, string imageUrl) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RemoveImagePlanLocationCommand(userId, planLocationId, imageUrl);

                var result = await sender.Send(command);

                var response = result.Adapt<RemoveImagePlanLocationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
