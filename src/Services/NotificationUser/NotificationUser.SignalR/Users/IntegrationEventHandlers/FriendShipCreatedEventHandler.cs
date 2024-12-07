
using NotificationUser.SignalR.Users.Commands.AddFriend;

namespace NotificationUser.SignalR.Users.IntegrationEventHandlers
{
    public class FriendShipCreatedEventHandler
        (ISender sender) : IConsumer<FriendShipCreatedEvent>
    {
        public async Task Consume(ConsumeContext<FriendShipCreatedEvent> context)
        {
            var userIdFirst = context.Message.UserIdFirst;
            var userIdSecond = context.Message.UserIdSecond;

            var command = new AddFriendCommand(userIdFirst, userIdSecond);
            await sender.Send(command);
        }
    }
}
