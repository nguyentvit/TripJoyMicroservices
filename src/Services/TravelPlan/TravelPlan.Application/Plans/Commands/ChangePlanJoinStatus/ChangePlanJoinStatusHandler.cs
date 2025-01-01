
namespace TravelPlan.Application.Plans.Commands.ChangePlanJoinStatus
{
    public class ChangePlanJoinStatusHandler
        (IApplicationDbContext dbContext) : ICommandHandler<ChangePlanJoinStatusCommand, ChangePlanJoinStatusResult>
    {
        public async Task<ChangePlanJoinStatusResult> Handle(ChangePlanJoinStatusCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            plan.ChangePlanJoinStatus(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new ChangePlanJoinStatusResult(true);
        }
    }
}
