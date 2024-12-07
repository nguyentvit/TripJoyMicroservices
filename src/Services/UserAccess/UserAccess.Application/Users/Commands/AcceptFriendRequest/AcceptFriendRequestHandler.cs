using BuildingBlocks.Messaging.Events.Event;

namespace UserAccess.Application.Users.Commands.AcceptFriendRequest
{
    public class AcceptFriendRequestHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint)
        : ICommandHandler<AcceptFriendRequestCommand, AcceptFriendRequestResult>
    {
        public async Task<AcceptFriendRequestResult> Handle(AcceptFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(command.Request.UserId);
            var user = await dbContext.Users.FindAsync([userId], cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.UserId);
            }

            var senderId = UserId.Of(command.Request.SenderId);
            var sender = await dbContext.Users.FindAsync([senderId], cancellationToken: cancellationToken);

            if (sender == null)
            {
                throw new UserNotFoundException(command.Request.SenderId);
            }

            user.AcceptFriendRequest(senderId);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new FriendShipCreatedEvent
            {
                UserIdFirst = userId.Value,
                UserIdSecond = senderId.Value
            };

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            return new AcceptFriendRequestResult(true);
        }
    }
}
