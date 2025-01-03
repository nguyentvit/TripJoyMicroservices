﻿namespace TravelPlan.Application.PlanLocations.Commands.AddPlanLocation
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

            if (plan.StartDate.Value.Date > command.PlanLocation.EstimatedStartDate.Date)
                throw new Exception($"Estimated start date of planLocation must be greater than Estimated start date of plan {plan.StartDate.Value}");

            var userId = UserId.Of(command.UserId);

            var location = await grpcService.GetLocationByCoordinates(latitude, longitude, command.PlanLocation.Name, command.PlanLocation.Address);

            var estimatedStartDate = Date.Of(command.PlanLocation.EstimatedStartDate);

            var order = 1;

            var PlanLocationsBeforePlanLocationAdded = await dbContext.PlanLocations.Where(pl => pl.PlanId == planId).ToListAsync(cancellationToken);

            foreach (var planLocationExisted in PlanLocationsBeforePlanLocationAdded)
            {
                if (planLocationExisted.EstimatedStartDate.Value.Date <= estimatedStartDate.Value.Date)
                {
                    ++order;
                }
                else
                {
                    var oldOrder = planLocationExisted.Order.Value;
                    planLocationExisted.ChangeOrder(PlanLocationOrder.Of(++oldOrder));
                }
            }

            


            var planLocation = PlanLocation.Of(planId, LocationId.Of(location.LocationId), estimatedStartDate, coordinates, PlanLocationOrder.Of(order));

            plan.AddPlanLocation(userId, planLocation.Id);

            dbContext.PlanLocations.Add(planLocation);

            await dbContext.SaveChangesAsync(cancellationToken);
            
            return new AddPlanLocationResult(planLocation.Id.Value);
        }
    }
}
