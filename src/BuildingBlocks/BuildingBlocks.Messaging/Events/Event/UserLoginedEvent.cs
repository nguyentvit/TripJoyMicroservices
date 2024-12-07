namespace BuildingBlocks.Messaging.Events.Event
{
    public record UserLoginedEvent : IntegrationEvent
    {
        public Guid UserId { get; set; } = default!;
    }
}
