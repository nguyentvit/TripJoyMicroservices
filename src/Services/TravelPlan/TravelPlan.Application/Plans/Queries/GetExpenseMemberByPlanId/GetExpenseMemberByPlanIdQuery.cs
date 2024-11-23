namespace TravelPlan.Application.Plans.Queries.GetExpenseMemberByPlanId
{
    public record GetExpenseMemberByPlanIdQuery(Guid UserId, Guid PlanId, PaginationRequest PaginationRequest, Guid TargetUserId) : IQuery<GetExpenseMemberByPlanIdQueryResult>;
    public record GetExpenseMemberByPlanIdQueryResult(Guid UserId, decimal Expense, decimal Excess, PaginationResult<ExpenseResponseDto> DetailExpense);
}
