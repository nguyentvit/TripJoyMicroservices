namespace BuildingBlocks.Messaging.Events.Event
{
    public record UserCreatedEvent : IntegrationEvent
    {
        public string AccountId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }
}
