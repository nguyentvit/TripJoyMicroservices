namespace TravelPlan.Application.PlanLocations.Commands.AddPlanLocation
{
    public class AddPlanLocationHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService grpcService)
        : ICommandHandler<AddPlanLocationCommand, AddPlanLocationResult>
    {
        public async Task<AddPlanLocationResult> Handle(AddPlanLocationCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var latitude = command.PlanLocation.Latitude;
            var longitude = command.PlanLocation.Longitude;
            var planLocationIds = plan.PlanLocationIds;
            var coordinates = Coordinates.Of(latitude, longitude);
            foreach (var planLocationId in planLocationIds)
            {
                var planLocationExisted = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
                if (planLocationExisted == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                if (planLocationExisted.Coordinates == coordinates)
                    throw new Exception("PlanLocation existed in plan");
            }

            var userId = UserId.Of(command.UserId);

            var location = await grpcService.GetLocationByCoordinates(latitude, longitude, command.PlanLocation.Name, command.PlanLocation.Address);

            var order = plan.PlanLocationIds.Count + 1;

            var planLocation = PlanLocation.Of(planId, LocationId.Of(location.LocationId), coordinates, PlanLocationOrder.Of(order));

            plan.AddPlanLocation(userId, planLocation.Id);

            dbContext.PlanLocations.Add(planLocation);

            await dbContext.SaveChangesAsync(cancellationToken);
            
            return new AddPlanLocationResult(planLocation.Id.Value);
        }
    }
}
