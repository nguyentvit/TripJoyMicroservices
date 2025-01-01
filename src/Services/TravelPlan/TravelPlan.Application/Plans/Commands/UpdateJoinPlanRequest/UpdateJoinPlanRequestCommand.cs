namespace TravelPlan.Application.Plans.Commands.UpdateJoinPlanRequest
{
    public record UpdateJoinPlanRequestCommand(Guid PlanId, Guid UserId, string Introduction) : ICommand<UpdateJoinPlanRequestResult>;
    public record UpdateJoinPlanRequestResult(bool IsSuccess);
}
