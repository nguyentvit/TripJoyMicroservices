using TravelPlan.Application.Plans.Queries.GetExpenseMemberByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetExpenseMemberByPlanIdResponse(Guid UserId, decimal Expense, decimal Excess, PaginationResult<ExpenseResponseDto> DetailExpense);
    public class GetExpenseMemberByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/expense/members/{targetUserId}", async (ISender sender, IHttpContextAccessor httpContext, Guid planId, [AsParameters] PaginationRequest request, Guid targetUserId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetExpenseMemberByPlanIdQuery(userId, planId, request, targetUserId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetExpenseMemberByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
