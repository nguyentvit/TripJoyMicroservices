namespace Identity.Application.DomainEvents
{
    public record UserCreatedDomainEvent(string userId, string email) : IDomainEvent;
}
