namespace TravelPlan.Application.Plans.Commands.AcceptInvitationMember
{
    public record AcceptInvitationMemberCommand(Guid PlanId, Guid UserId) : ICommand<AcceptInvitationMemberResult>;
    public record AcceptInvitationMemberResult(bool IsSuccess);
}
