namespace TravelPlan.Application.Plans.Queries.GetJoinPlanRequests
{
    public record GetJoinPlanRequestsQuery(PaginationRequest PaginationRequest, Guid PlanId, Guid UserId) : IQuery<GetJoinPlanRequestsResult>;
    public record GetJoinPlanRequestsResult(PaginationResult<GetJoinPlanRequestsDto> JoinPlanRequests);
}
