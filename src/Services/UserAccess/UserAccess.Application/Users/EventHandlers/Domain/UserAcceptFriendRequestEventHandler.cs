namespace UserAccess.Application.Users.EventHandlers.Domain
{
    public class UserAcceptFriendRequestEventHandler
        (ILogger<UserAcceptFriendRequestEventHandler> logger,
        IApplicationDbContext dbContext)
        : INotificationHandler<UserAcceptFriendRequestEvent>
    {
        public async Task Handle(UserAcceptFriendRequestEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            var userReceiverId = notification.User.Id;
            var userSenderId = notification.SenderId;

            var Sender = await dbContext.Users.FindAsync([userSenderId], cancellationToken: cancellationToken);

            if (Sender == null)
            {
                throw new UserNotFoundException(userSenderId.Value);
            }

            Sender.ReceiveAcceptFriendRequest(userReceiverId);
        }
    }
}
