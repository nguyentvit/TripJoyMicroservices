namespace TravelPlan.Application.Plans.Queries.GetPlanById
{
    public record GetPlanByIdQuery(Guid PlanId) : IQuery<GetPlanByIdResult>;
    public record GetPlanByIdResult(PlanDetailResponseDto Plan);
}
