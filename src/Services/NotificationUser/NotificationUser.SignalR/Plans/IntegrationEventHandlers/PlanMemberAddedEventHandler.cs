
using NotificationUser.SignalR.Plans.Commands.AddMember;

namespace NotificationUser.SignalR.Plans.IntegrationEventHandlers
{
    public class PlanMemberAddedEventHandler
        (ISender sender) : IConsumer<PlanMemberAddedEvent>
    {
        public async Task Consume(ConsumeContext<PlanMemberAddedEvent> context)
        {
            var planId = context.Message.PlanId;
            var userId = context.Message.UserId;

            var command = new AddMemberCommand(planId, userId);

            await sender.Send(command);
        }
    }
}
