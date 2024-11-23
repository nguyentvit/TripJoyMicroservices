namespace TravelPlan.Application.Plans.Queries.GetMembersByPlanId
{
    public record GetMembersByPlanIdQuery(PaginationRequest PaginationRequest, Guid UserId, Guid PlanId) : IQuery<GetMembersByPlanIdResult>;
    public record GetMembersByPlanIdResult(PaginationResult<PlanMemberResponseDto> Members);
}
