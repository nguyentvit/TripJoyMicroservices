using TravelPlan.Application.PlanLocations.Commands.ChangeOrderPlanLocation;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record ChangeOrderPlanLocationRequest(Guid PlanLocationIdFirst, Guid PlanLocationIdSecond);
    public record ChangeOrderPlanLocationResponse(bool IsSuccess);
    public class ChangeOrderPlanLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/plans/{planId}/planLocations/changeOrder", async (ISender sender, Guid planId, ChangeOrderPlanLocationRequest request, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var command = new ChangeOrderPlanLocationCommand(userId, planId, request.PlanLocationIdFirst, request.PlanLocationIdSecond);

                var result = await sender.Send(command);

                var response = result.Adapt<ChangeOrderPlanLocationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
