namespace TravelPlan.Application.Plans.Queries.GetPlanToSharePost
{
    public record GetPlanToSharePostQuery(Guid PlanId, Guid UserId) : IQuery<GetPlanToSharePostResult>;
    public record GetPlanToSharePostResult();
}
