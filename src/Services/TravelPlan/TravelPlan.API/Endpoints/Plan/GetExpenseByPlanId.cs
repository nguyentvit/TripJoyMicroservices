
using TravelPlan.Application.Plans.Queries.GetExpenseByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetExpenseByPlanIdResponse(decimal Expense);
    public class GetExpenseByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/expense", async (Guid planId, IHttpContextAccessor httpContext, ISender sender) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetExpenseByPlanIdQuery(planId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetExpenseByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
