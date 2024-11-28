using TravelPlan.Application.Plans.Commands.LeavePlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record PlanLeaveResponse(bool IsSuccess);
    public class PlanLeave : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/members/remove", async (IHttpContextAccessor httpContext, ISender sender, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var command = new LeavePlanCommand(userId, planId);

                var result = await sender.Send(command);

                var response = result.Adapt<PlanLeaveResponse>();

                return Results.Ok(response);
            });
        }
    }
}
