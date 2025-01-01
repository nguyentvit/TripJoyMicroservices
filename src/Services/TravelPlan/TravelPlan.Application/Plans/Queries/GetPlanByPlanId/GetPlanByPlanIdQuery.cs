namespace TravelPlan.Application.Plans.Queries.GetPlanByPlanId
{
    public record GetPlanByPlanIdQuery(Guid UserId, Guid PlanId) : IQuery<GetPlanByPlanIdResult>;
    public record GetPlanByPlanIdResult(PlanResponseDto Plan);
}
