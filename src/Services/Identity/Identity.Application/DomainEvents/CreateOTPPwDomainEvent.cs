﻿namespace Identity.Application.DomainEvents
{
    public record CreateOTPPwDomainEvent(string UserId, string Email) : IDomainEvent;
}
