
using TravelPlan.Application.Plans.Queries.GetPlanByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlanByPlanIdResponse(PlanResponseDto Plan);
    public class GetPlanByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}", async (ISender sender, IHttpContextAccessor httpContext, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPlanByPlanIdQuery(userId, planId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlanByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
