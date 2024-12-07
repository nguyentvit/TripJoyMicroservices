namespace TravelPlan.Application.Plans.EventHandlers
{
    public class UploadImageEventHandler
        (IS3Service s3Service) : IDomainEventHandler<UploadImageEvent>
    {
        public async Task Handle(UploadImageEvent notification, CancellationToken cancellationToken)
        {
            var avatar = notification.Avatar;
            string avatarUrl = await s3Service.UploadFileAsync(avatar.Value);

            Image avatarImage = Image.Of(avatarUrl);
            var plan = notification.Plan;
            var oldAvatar = (plan.Avatar == null) ? null : plan.Avatar;
            plan.UpdateAvatar(avatarImage);

            if (oldAvatar != null)
            {
                await s3Service.DeleteFileAsync(oldAvatar.Url);
            }
        }
    }
}
