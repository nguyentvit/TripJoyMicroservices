namespace Identity.Application.DomainEvents
{
    public record DisableOTPPwDomainEvent(string UserId) : IDomainEvent;
}
