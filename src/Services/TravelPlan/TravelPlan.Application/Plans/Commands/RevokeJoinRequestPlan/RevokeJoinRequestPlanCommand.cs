namespace TravelPlan.Application.Plans.Commands.RevokeJoinRequestPlan
{
    public record RevokeJoinRequestPlanCommand(Guid PlanId, Guid UserId) : ICommand<RevokeJoinRequestPlanResult>;
    public record RevokeJoinRequestPlanResult(bool IsSuccess);
}
