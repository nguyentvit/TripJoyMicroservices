namespace TravelPlan.Application.Plans.Commands.ChangePlanJoinStatus
{
    public record ChangePlanJoinStatusCommand(Guid PlanId, Guid UserId) : ICommand<ChangePlanJoinStatusResult>;
    public record ChangePlanJoinStatusResult(bool IsSuccess);
}
