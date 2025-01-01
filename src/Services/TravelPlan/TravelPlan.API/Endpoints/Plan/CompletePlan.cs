
using TravelPlan.Application.Plans.Commands.CompletePlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record CompletePlanResponse(bool IsSuccess);
    public class CompletePlan : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/complete", async (ISender sender, IHttpContextAccessor httpContext, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CompletePlanCommand(userId, planId);

                var result = await sender.Send(command);

                var response = result.Adapt<CompletePlanResponse>();

                return Results.Ok(response);
            });
        }
    }
}
