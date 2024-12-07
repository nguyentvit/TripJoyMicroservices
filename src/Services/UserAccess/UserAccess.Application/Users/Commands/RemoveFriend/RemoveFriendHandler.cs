using BuildingBlocks.Messaging.Events.Event;

namespace UserAccess.Application.Users.Commands.RemoveFriend
{
    public class RemoveFriendHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
        : ICommandHandler<RemoveFriendCommand, RemoveFriendResult>
    {
        public async Task<RemoveFriendResult> Handle(RemoveFriendCommand command, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(command.Request.UserId);
            var user = await dbContext.Users.FindAsync([userId], cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.UserId);
            }

            var friendId = UserId.Of(command.Request.FriendId);
            var friend = await dbContext.Users.FindAsync([friendId], cancellationToken: cancellationToken);

            if (friend == null)
            {
                throw new UserNotFoundException(command.Request.FriendId);
            }

            user.RemoveFriend(friendId);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new FriendShipRemovedEvent
            {
                UserIdFirst = userId.Value,
                UserIdSecond = friendId.Value
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new RemoveFriendResult(true);
        }
    }
}
