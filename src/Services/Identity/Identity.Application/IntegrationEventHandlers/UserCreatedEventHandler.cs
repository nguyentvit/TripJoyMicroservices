using BuildingBlocks.Messaging.Events.Event;
using Identity.Application.Command.UpdateUserId;
using MassTransit;

namespace Identity.Application.IntegrationEventHandlers
{
    public class UserCreatedEventHandler
        (ISender sender, IPublishEndpoint publishEndpoint)
        : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var eventMessage = new UserCreatedNotificationEvent { UserId = context.Message.UserId };
            await publishEndpoint.Publish(eventMessage);

            await sender.Send(new UpdateUserIdCommand(context.Message.AccountId, context.Message.UserId));
        }
    }
}
