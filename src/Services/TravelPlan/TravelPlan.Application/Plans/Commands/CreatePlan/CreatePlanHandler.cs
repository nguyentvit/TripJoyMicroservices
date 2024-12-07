namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public class CreatePlanHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
        : ICommandHandler<CreatePlanCommand, CreatePlanResult>
    {
        public async Task<CreatePlanResult> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            var provinceStartId = ProvinceId.Of(command.Plan.ProvinceStartId);
            var provinceEndId = ProvinceId.Of(command.Plan.ProvinceEndId);

            var provinceStart = await dbContext.Provinces.FindAsync([provinceStartId], cancellationToken);

            if (provinceStart == null)
                throw new ProvinceNotFoundException(provinceStartId.Value);

            var provinceEnd = await dbContext.Provinces.FindAsync([provinceEndId], cancellationToken);

            if (provinceEnd == null)
                throw new ProvinceNotFoundException(provinceEndId.Value);

            var newPlan = CreateNewPlan(command);
            dbContext.Plans.Add(newPlan);

            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new PlanCreatedEvent
            {
                PlanId = newPlan.Id.Value,
                UserId = command.UserId
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new CreatePlanResult(newPlan.Id.Value);
        }
        private Plan CreateNewPlan(CreatePlanCommand command)
        {
            return Plan.Of(
                title: Title.Of(command.Plan.Title),
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                method: command.Plan.Method,
                provinceStartId: ProvinceId.Of(command.Plan.ProvinceStartId),
                provinceEndId: ProvinceId.Of(command.Plan.ProvinceEndId),
                userId: UserId.Of(command.UserId),
                vehicle: command.Plan.Vehicle,
                avatar: (command.Plan.Avatar != null) ? FileImg.Of(command.Plan.Avatar) : null
                );
        }
    }
}
