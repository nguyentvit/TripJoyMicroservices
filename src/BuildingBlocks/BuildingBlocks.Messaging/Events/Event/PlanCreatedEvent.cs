namespace BuildingBlocks.Messaging.Events.Event
{
    public record PlanCreatedEvent : IntegrationEvent
    {
        public Guid PlanId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }
}
