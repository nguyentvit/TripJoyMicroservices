
namespace TravelPlan.Application.PlanLocations.Commands.RemovePlanLocation
{
    public class RemovePlanLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemovePlanLocationCommand, RemovePlanLocationResult>
    {
        public async Task<RemovePlanLocationResult> Handle(RemovePlanLocationCommand command, CancellationToken cancellationToken)
        {
            var planLocationId = PlanLocationId.Of(command.PlanLocationId);
            var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
            if (planLocation == null)
                throw new PlanLocationNotFoundException(planLocationId.Value);

            var planId = planLocation.PlanId;
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);

            dbContext.PlanLocations.Remove(planLocation);

            plan.RemovePlanLocation(userId, planLocation);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemovePlanLocationResult(true);
            
        }
    }
}
