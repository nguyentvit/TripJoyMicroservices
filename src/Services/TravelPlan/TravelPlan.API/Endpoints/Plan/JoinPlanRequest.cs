
using TravelPlan.Application.Plans.Commands.JoinRequestPlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record JoinPlanRequestRequest(string Introduction);
    public record JoinPlanRequestResponse(bool IsSuccess);
    public class JoinPlanRequest : ICarterModule

    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/join-request", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, JoinPlanRequestRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new JoinRequestPlanCommand(planId, userId, request.Introduction);

                var result = await sender.Send(command);

                var response = result.Adapt<JoinPlanRequestResponse>();

                return Results.Ok(response);
            });
        }
    }
}
