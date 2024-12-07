namespace BuildingBlocks.Messaging.Events.Event
{
    public record FriendShipRemovedEvent : IntegrationEvent
    {
        public Guid UserIdFirst { get; set; } = default!;
        public Guid UserIdSecond { get; set;} = default!;
    }
}
