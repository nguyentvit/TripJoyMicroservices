using BuildingBlocks.Interfaces;

namespace UserAccess.Application.Users.EventHandlers.Domain
{
    public class UploadImageEventHandler
        (IS3Service s3Service) : INotificationHandler<UploadImageEvent>
    {
        public async Task Handle(UploadImageEvent notification, CancellationToken cancellationToken)
        {
            var avatar = notification.Avatar;
            string avatarUrl = await s3Service.UploadFileAsync(avatar.Value);

            Image avatarImage = Image.Of(avatarUrl, ImageFormat.JPEG);
            var user = notification.User;
            user.UpdateAvatar(avatarImage);
        }
    }
}
