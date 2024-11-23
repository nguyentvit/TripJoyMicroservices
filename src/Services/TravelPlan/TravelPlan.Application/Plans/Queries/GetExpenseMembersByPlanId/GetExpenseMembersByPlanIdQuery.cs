namespace TravelPlan.Application.Plans.Queries.GetExpenseMembersByPlanId
{
    public record GetExpenseMembersByPlanIdQuery(PaginationRequest PaginationRequest, Guid UserId, Guid PlanId) : IQuery<GetExpenseMembersByPlanIdResult>;
    public record GetExpenseMembersByPlanIdResult(PaginationResult<PlanExpenseMembersResponseDto> Members);
}
