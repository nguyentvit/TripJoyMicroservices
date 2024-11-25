namespace TravelPlan.Application.Plans.Commands.StartPlan
{
    public record StartPlanCommand(Guid PlanId, Guid UserId) : ICommand<StartPlanResult>;
    public record StartPlanResult(bool IsSuccess);
}
