namespace TravelPlan.Application.Plans.Queries.GetExpenseByPlanId
{
    public record GetExpenseByPlanIdQuery(Guid PlanId, Guid UserId) : IQuery<GetExpenseByPlanIdResult>;
    public record GetExpenseByPlanIdResult(decimal Expense);
}
