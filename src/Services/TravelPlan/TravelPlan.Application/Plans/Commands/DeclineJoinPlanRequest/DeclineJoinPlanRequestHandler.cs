
namespace TravelPlan.Application.Plans.Commands.DeclineJoinPlanRequest
{
    public class DeclineJoinPlanRequestHandler
        (IApplicationDbContext dbContext) : ICommandHandler<DeclineJoinPlanRequestCommand, DeclineJoinPlanRequestResult>
    {
        public async Task<DeclineJoinPlanRequestResult> Handle(DeclineJoinPlanRequestCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);

            plan.DeclineJoinPlanRequest(userId, targetUserId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeclineJoinPlanRequestResult(true);
        }
    }
}
