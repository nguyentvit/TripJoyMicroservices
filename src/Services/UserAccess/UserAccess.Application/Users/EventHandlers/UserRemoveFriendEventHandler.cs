namespace UserAccess.Application.Users.EventHandlers
{
    public class UserRemoveFriendEventHandler
        (ILogger<UserRemoveFriendEventHandler> logger,
        IApplicationDbContext dbContext)
        : INotificationHandler<UserRemoveFriendEvent>
    {
        public async Task Handle(UserRemoveFriendEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            var userId = notification.User.Id;
            var friendId = notification.FriendId;

            var friend = await dbContext.Users.FindAsync([friendId], cancellationToken: cancellationToken);

            if (friend == null)
            {
                throw new UserNotFoundException(friendId.Value.ToString());
            }

            friend.RemoveFriend(userId, false);
        }
    }
}
