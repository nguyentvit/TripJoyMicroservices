using TravelPlan.Application.Plans.Commands.PausePlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record PlanPauseResponse(bool IsSuccess);
    public class PlanPause : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/pause", async (IHttpContextAccessor httpContext, ISender sender, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new PausePlanCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<PlanPauseResponse>();

                return Results.Ok(response);
            });
        }
    }
}
