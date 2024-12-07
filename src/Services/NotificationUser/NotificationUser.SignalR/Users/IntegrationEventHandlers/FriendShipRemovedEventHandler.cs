
using NotificationUser.SignalR.Users.Commands.RemoveFriend;

namespace NotificationUser.SignalR.Users.IntegrationEventHandlers
{
    public class FriendShipRemovedEventHandler
        (ISender sender) : IConsumer<FriendShipRemovedEvent>
    {
        public async Task Consume(ConsumeContext<FriendShipRemovedEvent> context)
        {
            var userIdFirst = context.Message.UserIdFirst;
            var userIdSecond = context.Message.UserIdSecond;

            var command = new RemoveFriendCommand(userIdFirst, userIdSecond);
            await sender.Send(command);
        }
    }
}
