
namespace TravelPlan.Application.Plans.Commands.PausePlan
{
    public class PausePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<PausePlanCommand, PausePlanResult>
    {
        public async Task<PausePlanResult> Handle(PausePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            plan.PausePlan(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new PausePlanResult(true);
        }
    }
}
