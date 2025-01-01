
namespace TravelPlan.Application.Plans.Commands.UpdateJoinPlanRequest
{
    public class UpdateJoinPlanRequestHandler
        (IApplicationDbContext dbContext) : ICommandHandler<UpdateJoinPlanRequestCommand, UpdateJoinPlanRequestResult>
    {
        public async Task<UpdateJoinPlanRequestResult> Handle(UpdateJoinPlanRequestCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var planJoinRequest = plan.PlanJoinRequests.FirstOrDefault(j => j.UserId == userId);
            if (planJoinRequest == null)
                throw new Exception($"Join request with UserId {userId.Value} not found.");

            var introduction = Introduction.Of(command.Introduction);
            planJoinRequest.UpdateIntroduction(introduction);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateJoinPlanRequestResult(true);
        }
    }
}
