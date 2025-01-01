namespace TravelPlan.Application.Plans.Commands.DeclineJoinPlanRequest
{
    public record DeclineJoinPlanRequestCommand(Guid PlanId, Guid UserId, Guid TargetUserId) : ICommand<DeclineJoinPlanRequestResult>;
    public record DeclineJoinPlanRequestResult(bool IsSuccess);
}
