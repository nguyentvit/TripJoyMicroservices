namespace TravelPlan.Application.Plans.Commands.DeclineInvitationMember
{
    public record DeclineInvitationMemberCommand(Guid PlanId, Guid UserId) : ICommand<DeclineInvitationMemberResult>;
    public record DeclineInvitationMemberResult(bool IsSuccess);
}
