namespace TravelPlan.Application.Plans.Queries.GetExpenseMeByPlanId
{
    public record GetExpenseMeByPlanIdQuery(Guid UserId, Guid PlanId, PaginationRequest PaginationRequest) : IQuery<GetExpenseMeByPlanIdResult>;
    public record GetExpenseMeByPlanIdResult(decimal TotalExpense, decimal Expense, decimal Excess, PaginationResult<ExpenseResponseDto> DetailExpense);
}
