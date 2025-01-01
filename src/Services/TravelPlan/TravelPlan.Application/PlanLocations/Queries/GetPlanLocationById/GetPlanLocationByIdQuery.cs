namespace TravelPlan.Application.PlanLocations.Queries.GetPlanLocationById
{
    public record GetPlanLocationByIdQuery(Guid PlanLocationId, Guid UserId) : IQuery<GetPlanLocationByIdResult>;
    public record GetPlanLocationByIdResult(PlanLocationResponseDto PlanLocation);
}
