namespace Identity.Application.DomainEvents
{
    public record ConfirmEmailDomainEvent(string userId) : IDomainEvent;
}
