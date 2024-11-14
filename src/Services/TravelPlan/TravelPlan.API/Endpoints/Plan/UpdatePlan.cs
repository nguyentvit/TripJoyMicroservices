using TravelPlan.Application.Plans.Commands.UpdatePlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record UpdatePlanRequest(PlanUpdateDto Plan);
    public record UpdatePlanResponse(bool IsSuccess);
    public class UpdatePlan : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plan/{planId}", async (Guid planId,UpdatePlanRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new UpdatePlanCommand(request.Plan, userId, planId);

                var result = await sender.Send(command);

                var response = result.Adapt<UpdatePlanResponse>();

                return Results.Ok(response);
            });
        }
    }
}
