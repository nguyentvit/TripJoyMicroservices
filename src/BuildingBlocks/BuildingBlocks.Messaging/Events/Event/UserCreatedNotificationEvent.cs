namespace BuildingBlocks.Messaging.Events.Event
{
    public record UserCreatedNotificationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; } = default!;
    }
}
