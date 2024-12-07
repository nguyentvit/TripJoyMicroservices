namespace TravelPlan.Application.PlanLocations.Commands.RemoveImagePlanLocation
{
    public class RemoveImagePlanLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemoveImagePlanLocationCommand, RemoveImagePlanLocationResult>
    {
        public async Task<RemoveImagePlanLocationResult> Handle(RemoveImagePlanLocationCommand command, CancellationToken cancellationToken)
        {
            var planLocationId = PlanLocationId.Of(command.PlanLocationId);
            var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
            if (planLocation == null)
                throw new PlanLocationNotFoundException(planLocationId.Value);

            var plan = await dbContext.Plans.FindAsync([planLocation.PlanId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planLocation.PlanId.Value);

            var userId = UserId.Of(command.UserId);

            plan.EditPlanLocation(userId);

            var image = Image.Of(command.ImageUrl);
            planLocation.RemoveImagePlanLocation(image);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveImagePlanLocationResult(true);
        }
    }
}
