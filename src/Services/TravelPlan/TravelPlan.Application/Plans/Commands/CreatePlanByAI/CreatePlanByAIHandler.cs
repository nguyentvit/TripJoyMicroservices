
namespace TravelPlan.Application.Plans.Commands.CreatePlanByAI
{
    public class CreatePlanByAIHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService grpcService,
        IPublishEndpoint publishEndpoint) : ICommandHandler<CreatePlanByAICommand, CreatePlanByAIResult>
    {
        public async Task<CreatePlanByAIResult> Handle(CreatePlanByAICommand command, CancellationToken cancellationToken)
        {
            var provinceNameStart = ProvinceName.Of(command.Plan.ProvinceStart);
            var provinceStart = await dbContext.Provinces.FirstOrDefaultAsync(p => p.Name == provinceNameStart, cancellationToken);

            if (provinceStart == null)
                throw new ProvinceNotFoundException(Guid.NewGuid());

            var provinceNameEnd = ProvinceName.Of(command.Plan.ProvinceEnd);
            var provinceEnd = await dbContext.Provinces.FirstOrDefaultAsync(p => p.Name == provinceNameEnd, cancellationToken);

            if (provinceEnd == null)
                throw new ProvinceNotFoundException(Guid.NewGuid());

            var userId = UserId.Of(command.UserId);
            var newPlan = CreateNewPlan(command, provinceStart, provinceEnd);

            dbContext.Plans.Add(newPlan);

            var planId = newPlan.Id;

            int order = 0;
            foreach (var planLocation in command.Plan.PlanLocations)
            {
                var location = await grpcService.GetLocationByCoordinates(planLocation.Latitude, planLocation.Longitude, planLocation.Name, planLocation.Address);

                var planLocationAdd = PlanLocation.Of(planId, LocationId.Of(location.LocationId), Date.Of(planLocation.EstimatedStartDate), Coordinates.Of(planLocation.Latitude, planLocation.Longitude), PlanLocationOrder.Of(++order));

                newPlan.AddPlanLocation(userId, planLocationAdd.Id);

                dbContext.PlanLocations.Add(planLocationAdd);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new PlanCreatedEvent
            {
                PlanId = newPlan.Id.Value,
                UserId = command.UserId
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new CreatePlanByAIResult(newPlan.Id.Value);
        }
        private Plan CreateNewPlan(CreatePlanByAICommand command, Province provinceStart, Province provinceEnd)
        {
            return Plan.Of(
                title: Title.Of(command.Plan.Title),
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                method: command.Plan.Method,
                provinceStartId: provinceStart.Id,
                provinceEndId: provinceEnd.Id,
                userId: UserId.Of(command.UserId),
                vehicle: command.Plan.Vehicle,
                avatar: null
                );
        }
    }
}
