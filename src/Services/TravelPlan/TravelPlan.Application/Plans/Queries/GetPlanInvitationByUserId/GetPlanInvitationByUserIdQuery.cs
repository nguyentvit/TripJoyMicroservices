namespace TravelPlan.Application.Plans.Queries.GetPlanInvitationByUserId
{
    public record GetPlanInvitationByUserIdQuery(PaginationRequest PaginationRequest, Guid UserId) : IQuery<GetPlanInvitationByUserIdResult>;
    public record GetPlanInvitationByUserIdResult(PaginationResult<PlanInvitationByUserIdDto> PlanInvitations);
}
