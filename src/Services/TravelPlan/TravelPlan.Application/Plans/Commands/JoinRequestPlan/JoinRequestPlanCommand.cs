namespace TravelPlan.Application.Plans.Commands.JoinRequestPlan
{
    public record JoinRequestPlanCommand(Guid PlanId, Guid UserId, string Introduction) : ICommand<JoinRequestPlanResult>;
    public record JoinRequestPlanResult(bool IsSuccess);
}
