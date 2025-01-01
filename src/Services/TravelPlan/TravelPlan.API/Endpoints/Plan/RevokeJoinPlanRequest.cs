
using TravelPlan.Application.Plans.Commands.RevokeJoinRequestPlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record RevokeJoinPlanRequestResponse(bool IsSuccess);
    public class RevokeJoinPlanRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/revoke-join-request", async (ISender sender, IHttpContextAccessor httpContext, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RevokeJoinRequestPlanCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<RevokeJoinPlanRequestResponse>();

                return Results.Ok(response);
            });
        }
    }
}
