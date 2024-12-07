namespace BuildingBlocks.Messaging.Events.Event
{
    public record PlanMemberAddedEvent : IntegrationEvent
    {
        public Guid PlanId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }
}
