namespace UserAccess.Domain.Events
{
    public record UserUpdatedEvent(User User) : IDomainEvent;
}
