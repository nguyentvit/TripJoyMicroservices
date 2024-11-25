namespace TravelPlan.Application.Plans.Commands.PausePlan
{
    public record PausePlanCommand(Guid PlanId, Guid UserId) : ICommand<PausePlanResult>;
    public record PausePlanResult(bool IsSucces);
}
