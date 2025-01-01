
using TravelPlan.Application.Plans.Commands.UpdateJoinPlanRequest;

namespace TravelPlan.API.Endpoints.Plan
{
    public record UpdateJoinPlanRequestRequest(string Introduction);
    public record UpdateJoinPlanRequestResponse(bool IsSuccess);
    public class UpdateJoinPlanRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/join-request", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, UpdateJoinPlanRequestRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new UpdateJoinPlanRequestCommand(planId, userId, request.Introduction);

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateJoinPlanRequestResponse>();

                return Results.Ok(response);
            });
        }
    }
}
