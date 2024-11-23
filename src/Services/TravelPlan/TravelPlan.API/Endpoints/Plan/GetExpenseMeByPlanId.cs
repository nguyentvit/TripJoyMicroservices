using TravelPlan.Application.Plans.Queries.GetExpenseMeByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetExpenseMeByPlanIdResponse(decimal Expense,decimal Excess, PaginationResult<ExpenseResponseDto> DetailExpense);
    public class GetExpenseMeByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/expense/me", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetExpenseMeByPlanIdQuery(userId, planId, request);

                var result = await sender.Send(query);

                var response = result.Adapt<GetExpenseMeByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
