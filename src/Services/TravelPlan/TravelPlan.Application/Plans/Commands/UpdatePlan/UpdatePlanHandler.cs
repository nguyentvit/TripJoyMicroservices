namespace TravelPlan.Application.Plans.Commands.UpdatePlan
{
    public class UpdatePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
    {
        public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);

            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            UpdatePlan(plan, command);
            dbContext.Plans.Update(plan);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePlanResult(true);

        }
        private void UpdatePlan(Plan plan, UpdatePlanCommand command)
        {
            plan.UpdatePlan(
                title: Title.Of(command.Plan.Title),
                avatar: (command.Plan.Avatar != null) ? Image.Of(command.Plan.Avatar) : null,
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                visibility: command.Plan.Visibility,
                userId: UserId.Of(command.UserId)
                );
        }
    }
}
