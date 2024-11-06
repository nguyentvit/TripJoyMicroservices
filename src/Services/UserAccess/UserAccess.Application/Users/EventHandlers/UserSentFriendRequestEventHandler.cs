namespace UserAccess.Application.Users.EventHandlers
{
    public class UserSentFriendRequestEventHandler
        (ILogger<UserSentFriendRequestEventHandler> logger,
        IApplicationDbContext dbContext)
        : INotificationHandler<UserSentFriendRequestEvent>
    {
        public async Task Handle(UserSentFriendRequestEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            var userSenderId = notification.User.Id;
            var userReceiverId = notification.ReceiverId;

            var Receiver = await dbContext.Users.FindAsync([userReceiverId], cancellationToken: cancellationToken);

            if (Receiver == null)
            {
                throw new UserNotFoundException(userReceiverId.Value.ToString());
            }

            Receiver.ReceiveFriendRequest(userSenderId);
        }
    }
}
