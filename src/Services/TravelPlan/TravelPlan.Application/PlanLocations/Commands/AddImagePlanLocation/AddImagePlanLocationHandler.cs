
namespace TravelPlan.Application.PlanLocations.Commands.AddImagePlanLocation
{
    public class AddImagePlanLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<AddImagePlanLocationCommand, AddImagePlanLocationResult>
    {
        public async Task<AddImagePlanLocationResult> Handle(AddImagePlanLocationCommand command, CancellationToken cancellationToken)
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

            var image = FileImg.Of(command.Image);
            planLocation.AddImagePlanLocation(image, userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddImagePlanLocationResult(true);
        }
    }
}
