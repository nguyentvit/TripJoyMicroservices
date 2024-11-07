namespace UserAccess.Application.Users.Commands.DeclineFriendRequest
{
    public class DeclineFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<DeclineFriendRequestCommand, DeclineFriendRequestResult>
    {
        public async Task<DeclineFriendRequestResult> Handle(DeclineFriendRequestCommand command, CancellationToken cancellationToken)
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

            user.DeclineFriendRequest(senderId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeclineFriendRequestResult(true);
        }
    }
}
