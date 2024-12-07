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

            var oldAvatar = (user.Avatar == null) ? null : user.Avatar;

            user.UpdateAvatar(avatarImage);

            if (oldAvatar != null)
            {
                await s3Service.DeleteFileAsync(oldAvatar.Url);
            }
        }
    }
}
