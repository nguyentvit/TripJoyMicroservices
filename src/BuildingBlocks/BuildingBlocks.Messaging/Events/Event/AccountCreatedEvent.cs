namespace BuildingBlocks.Messaging.Events.Event
{
    public record AccountCreatedEvent : IntegrationEvent
    {
        public string AccountId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
