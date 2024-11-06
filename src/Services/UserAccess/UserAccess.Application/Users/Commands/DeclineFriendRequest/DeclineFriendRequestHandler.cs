namespace UserAccess.Application.Users.Commands.DeclineFriendRequest
{
    public class DeclineFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<DeclineFriendRequestCommand, DeclineFriendRequestResult>
    {
        public async Task<DeclineFriendRequestResult> Handle(DeclineFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.Request.AccountId);
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.AccountId == accountId, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.AccountId);
            }

            var senderId = UserId.Of(command.Request.SenderId);
            var sender = await dbContext.Users.FindAsync([senderId], cancellationToken: cancellationToken);

            if (sender == null)
            {
                throw new UserNotFoundException(command.Request.SenderId.ToString());
            }

            user.DeclineFriendRequest(senderId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeclineFriendRequestResult(true);
        }
    }
}
