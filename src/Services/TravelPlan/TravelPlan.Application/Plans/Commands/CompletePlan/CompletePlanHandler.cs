
namespace TravelPlan.Application.Plans.Commands.CompletePlan
{
    public class CompletePlanHandler
        (IApplicationDbContext dbContext) : ICommandHandler<CompletePlanCommand, CompletePlanResult>
    {
        public async Task<CompletePlanResult> Handle(CompletePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            plan.CompletePlan(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CompletePlanResult(true);
        }
    }
}
