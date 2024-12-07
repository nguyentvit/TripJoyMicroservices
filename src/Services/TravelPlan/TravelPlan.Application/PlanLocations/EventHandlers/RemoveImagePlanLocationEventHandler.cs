
namespace TravelPlan.Application.PlanLocations.EventHandlers
{
    public class RemoveImagePlanLocationEventHandler
        (IS3Service s3Service) : IDomainEventHandler<RemoveImagePlanLocationEvent>
    {
        public async Task Handle(RemoveImagePlanLocationEvent notification, CancellationToken cancellationToken)
        {
            var image = notification.Image;
            await s3Service.DeleteFileAsync(image.Url);

            var planLocation = notification.PlanLocation;
            planLocation.RemoveImagePlanLocationHandler(image);
        }
    }
}
