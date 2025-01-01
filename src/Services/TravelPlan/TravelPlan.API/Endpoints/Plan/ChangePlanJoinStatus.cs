
using TravelPlan.Application.Plans.Commands.ChangePlanJoinStatus;

namespace TravelPlan.API.Endpoints.Plan
{
    public record ChangePlanJoinStatusResponse(bool IsSuccess);
    public class ChangePlanJoinStatus : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/change-join-status", async (ISender sender, IHttpContextAccessor httpContext, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new ChangePlanJoinStatusCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<ChangePlanJoinStatusResponse>();

                return Results.Ok(response);
            });
        }
    }
}
