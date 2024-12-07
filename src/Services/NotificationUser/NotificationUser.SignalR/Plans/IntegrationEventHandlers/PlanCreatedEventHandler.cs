
using NotificationUser.SignalR.Plans.Commands.CreatePlan;

namespace NotificationUser.SignalR.Plans.IntegrationEventHandlers
{
    public class PlanCreatedEventHandler
        (ISender sender) : IConsumer<PlanCreatedEvent>
    {
        public async Task Consume(ConsumeContext<PlanCreatedEvent> context)
        {
            var planId = context.Message.PlanId;
            var userId = context.Message.UserId;

            var command = new CreatePlanCommand(planId, userId);

            await sender.Send(command);
        }
    }
}
