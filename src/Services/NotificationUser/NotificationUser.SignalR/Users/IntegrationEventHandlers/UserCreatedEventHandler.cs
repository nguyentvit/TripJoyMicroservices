using NotificationUser.SignalR.Users.Commands.CreateUser;

namespace NotificationUser.SignalR.Users.IntegrationEventHandlers
{
    public class UserCreatedEventHandler
        (ISender sender) : IConsumer<UserCreatedNotificationEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedNotificationEvent> context)
        {
            var userId = context.Message.UserId;
            var command = new CreateUserCommand(userId);
            await sender.Send(command);
        }
    }
}
