﻿namespace UserAccess.Domain.Events
{
    public record UserCreatedEvent(User User) : IDomainEvent;
}
