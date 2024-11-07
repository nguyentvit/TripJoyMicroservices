namespace UserAccess.Application.Users.EventHandlers.Domain
{
    public class UserCreatedEventHandler
        (ILogger<UserCreatedEventHandler> logger)
        : INotificationHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
