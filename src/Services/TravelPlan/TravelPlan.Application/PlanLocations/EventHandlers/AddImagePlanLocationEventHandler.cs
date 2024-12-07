namespace TravelPlan.Application.PlanLocations.EventHandlers
{
    public class AddImagePlanLocationEventHandler
        (IS3Service s3Service) : IDomainEventHandler<AddImagePlanLocationEvent>
    {
        public async Task Handle(AddImagePlanLocationEvent notification, CancellationToken cancellationToken)
        {
            var img = notification.Image;
            string imgUrl = await s3Service.UploadFileAsync(img.Value);

            Image imgImage = Image.Of(imgUrl);
            var planLocation = notification.PlanLocation;

            planLocation.AddImagePlanLocationHandler(imgImage, notification.UserId);
        }
    }
}
