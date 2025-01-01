
namespace TravelPlan.Application.Plans.Commands.AcceptJoinPlanRequest
{
    public class AcceptJoinPlanRequestHandler
        (IApplicationDbContext dbContext) : ICommandHandler<AcceptJoinPlanRequestCommand, AcceptJoinPlanRequestResult>
    {
        public async Task<AcceptJoinPlanRequestResult> Handle(AcceptJoinPlanRequestCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var targetUserId = UserId.Of(command.TargetUserId);
            plan.AcceptJoinPlanRequest(userId, targetUserId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new AcceptJoinPlanRequestResult(true);
        }
    }
}
