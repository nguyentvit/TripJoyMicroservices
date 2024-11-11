namespace LocationAttraction.Domain.Events
{
    public record LocationCreatedEvent(Location Location) : IDomainEvent;
}
