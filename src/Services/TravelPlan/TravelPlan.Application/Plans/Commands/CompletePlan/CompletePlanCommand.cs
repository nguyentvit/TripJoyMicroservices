namespace TravelPlan.Application.Plans.Commands.CompletePlan
{
    public record CompletePlanCommand(Guid UserId, Guid PlanId) : ICommand<CompletePlanResult>;
    public record CompletePlanResult(bool IsSuccess);
}
