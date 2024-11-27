
using TravelPlan.Application.Plans.Commands.StartPlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record PlanStartResponse(bool IsSuccess);
    public class PlanStart : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/start", async (Guid planId, IHttpContextAccessor httpContext, ISender sender) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new StartPlanCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<PlanStartResponse>();

                return Results.Ok(response);
            });
        }
    }
}
