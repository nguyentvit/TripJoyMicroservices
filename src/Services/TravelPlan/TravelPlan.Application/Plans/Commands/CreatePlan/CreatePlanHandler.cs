namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public class CreatePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<CreatePlanCommand, CreatePlanResult>
    {
        public async Task<CreatePlanResult> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            var newPlan = CreateNewPlan(command);

            dbContext.Plans.Add(newPlan);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePlanResult(newPlan.Id.Value);
        }
        private Plan CreateNewPlan(CreatePlanCommand command)
        {
            return Plan.Of(
                title: Title.Of(command.Plan.Title),
                avatar: (command.Plan.Avatar != null) ? Image.Of(command.Plan.Avatar) : null,
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                visibility: command.Plan.Visibility,
                method: command.Plan.Method,
                userId: UserId.Of(command.UserId)
                );
        }
    }
}
