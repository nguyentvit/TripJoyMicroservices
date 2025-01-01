
using TravelPlan.Application.Plans.Commands.AcceptJoinPlanRequest;

namespace TravelPlan.API.Endpoints.Plan
{
    public record AcceptJoinPlanRequestResponse(bool IsSuccess);
    public class AcceptJoinPlanRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/join-request/accept/{targetUserId}", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, Guid targetUserId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new AcceptJoinPlanRequestCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);

                var response = result.Adapt<AcceptJoinPlanRequestResponse>();

                return Results.Ok(response);
            });
        }
    }
}
