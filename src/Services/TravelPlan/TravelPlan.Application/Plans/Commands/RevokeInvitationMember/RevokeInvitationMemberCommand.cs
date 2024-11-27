namespace TravelPlan.Application.Plans.Commands.RevokeInvitationMember
{
    public record RevokeInvitationMemberCommand(Guid UserId, Guid TargetUserId, Guid PlanId) : ICommand<RevokeInvitationMemberResult>;
    public record RevokeInvitationMemberResult(bool IsSuccess);
}
