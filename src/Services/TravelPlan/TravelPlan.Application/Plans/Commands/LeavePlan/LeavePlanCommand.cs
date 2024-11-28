namespace TravelPlan.Application.Plans.Commands.LeavePlan
{
    public record LeavePlanCommand(Guid UserId, Guid PlanId) : ICommand<LeavePlanResult>;
    public record LeavePlanResult(bool IsSuccess);
}
