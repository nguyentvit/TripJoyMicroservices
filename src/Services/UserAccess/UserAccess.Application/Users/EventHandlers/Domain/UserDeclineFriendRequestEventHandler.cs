namespace UserAccess.Application.Users.EventHandlers.Domain
{
    public class UserDeclineFriendRequestEventHandler
        (ILogger<UserDeclineFriendRequestEventHandler> logger,
        IApplicationDbContext dbContext)
        : INotificationHandler<UserDeclineFriendRequestEvent>
    {
        public async Task Handle(UserDeclineFriendRequestEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            var userReceiverId = notification.User.Id;
            var userSenderId = notification.SenderId;

            var Sender = await dbContext.Users.FindAsync([userSenderId], cancellationToken: cancellationToken);

            if (Sender == null)
            {
                throw new UserNotFoundException(userSenderId.Value);
            }

            Sender.ReceiveDeclineFriendRequest(userReceiverId);
        }
    }
}
