namespace TravelPlan.Application.PlanLocations.Queries.GetPlanLocationByPlanId
{
    public record GetPlanLocationByPlanIdQuery(PaginationRequest PaginationRequest, Guid UserId, Guid PlanId) : IQuery<GetPlanLocationByPlanIdResult>;
    public record GetPlanLocationByPlanIdResult(PaginationResult<PlanLocationResponseDto> PlanLocations);
}
