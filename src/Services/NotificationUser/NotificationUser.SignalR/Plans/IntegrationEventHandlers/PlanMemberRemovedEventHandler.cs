using NotificationUser.SignalR.Plans.Commands.RemoveMember;

namespace NotificationUser.SignalR.Plans.IntegrationEventHandlers
{
    public class PlanMemberRemovedEventHandler
        (ISender sender) : IConsumer<PlanMemberRemovedEvent>
    {
        public async Task Consume(ConsumeContext<PlanMemberRemovedEvent> context)
        {
            var planId = context.Message.PlanId;
            var userId = context.Message.UserId;

            var command = new RemoveMemberCommand(planId, userId);

            await sender.Send(command);
        }
    }
}
