namespace TravelPlan.Application.Plans.Queries.GetUsersAvailableAddMember
{
    public record GetUsersAvailableAddMemberQuery(PaginationRequest PaginationRequest, KeySearchUser KeySearch, Guid PlanId, Guid UserId) : IQuery<GetUsersAvailableAddMemberResult>;
    public record GetUsersAvailableAddMemberResult(PaginationResult<PlanInvitationUserAvailableDto> Users);
}
