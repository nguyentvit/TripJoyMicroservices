namespace TravelPlan.Application.Plans.Commands.StartPlan
{
    public class StartPlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<StartPlanCommand, StartPlanResult>
    {
        public async Task<StartPlanResult> Handle(StartPlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            plan.StartPlan(userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new StartPlanResult(true);
        }
    }
}
