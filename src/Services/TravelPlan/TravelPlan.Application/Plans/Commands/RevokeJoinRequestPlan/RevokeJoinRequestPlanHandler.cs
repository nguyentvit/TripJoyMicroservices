
namespace TravelPlan.Application.Plans.Commands.RevokeJoinRequestPlan
{
    public class RevokeJoinRequestPlanHandler
        (IApplicationDbContext dbContext) : ICommandHandler<RevokeJoinRequestPlanCommand, RevokeJoinRequestPlanResult>
    {
        public async Task<RevokeJoinRequestPlanResult> Handle(RevokeJoinRequestPlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            plan.RevokeJoinRequestPlan(userId);

            await dbContext.SaveChangesAsync(cancellationToken);
            return new RevokeJoinRequestPlanResult(true);
        }
    }
}
