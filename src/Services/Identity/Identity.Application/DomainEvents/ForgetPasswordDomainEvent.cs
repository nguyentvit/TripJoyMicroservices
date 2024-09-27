namespace Identity.Application.DomainEvents
{
    public record ForgetPasswordDomainEvent(string UserId, string Email) : IDomainEvent;
}
