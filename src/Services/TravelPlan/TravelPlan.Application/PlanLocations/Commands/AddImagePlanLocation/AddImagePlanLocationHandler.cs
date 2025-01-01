
namespace TravelPlan.Application.PlanLocations.Commands.AddImagePlanLocation
{
    public class AddImagePlanLocationHandler
        (IApplicationDbContext dbContext,
        IS3Service s3Service)
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

            string imgUrl = await s3Service.UploadFileAsync(command.Image);

            Image imgImage = Image.Of(imgUrl);

            planLocation.AddImagePlanLocationHandler(imgImage, userId);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddImagePlanLocationResult(imgUrl, true);
        }
    }
}
