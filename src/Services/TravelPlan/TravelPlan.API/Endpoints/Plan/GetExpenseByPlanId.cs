using TravelPlan.Application.Plans.Queries.GetExpenseMeByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetExpenseByPlanIdResponse(decimal TotalExpense, decimal Expense,decimal Excess, PaginationResult<ExpenseResponseDto> DetailExpense);
    public class GetExpenseByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/expense", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetExpenseMeByPlanIdQuery(userId, planId, request);

                var result = await sender.Send(query);

                var response = result.Adapt<GetExpenseByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
