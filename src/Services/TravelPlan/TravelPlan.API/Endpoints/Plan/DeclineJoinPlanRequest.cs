
using TravelPlan.Application.Plans.Commands.DeclineJoinPlanRequest;

namespace TravelPlan.API.Endpoints.Plan
{
    public record DeclineJoinPlanRequestResponse(bool IsSuccess);
    public class DeclineJoinPlanRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/join-request/decline/{targetUserId}", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, Guid targetUserId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new DeclineJoinPlanRequestCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);

                var response = result.Adapt<DeclineJoinPlanRequestResponse>();

                return Results.Ok(response);
            });
        }
    }
}
