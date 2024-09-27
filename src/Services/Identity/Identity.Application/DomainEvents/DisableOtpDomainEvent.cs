namespace Identity.Application.DomainEvents
{
    public record DisableOtpDomainEvent(string userId) : IDomainEvent;
}
