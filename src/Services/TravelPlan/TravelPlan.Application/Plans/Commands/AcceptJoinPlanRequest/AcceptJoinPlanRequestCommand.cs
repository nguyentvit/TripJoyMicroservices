namespace TravelPlan.Application.Plans.Commands.AcceptJoinPlanRequest
{
    public record AcceptJoinPlanRequestCommand(Guid PlanId, Guid UserId, Guid TargetUserId) : ICommand<AcceptJoinPlanRequestResult>;
    public record AcceptJoinPlanRequestResult(bool IsSuccess);
}
