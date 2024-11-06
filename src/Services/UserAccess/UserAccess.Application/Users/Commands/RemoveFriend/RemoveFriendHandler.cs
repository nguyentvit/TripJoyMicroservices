namespace UserAccess.Application.Users.Commands.RemoveFriend
{
    public class RemoveFriendHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RemoveFriendCommand, RemoveFriendResult>
    {
        public async Task<RemoveFriendResult> Handle(RemoveFriendCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.Request.AccountId);
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.AccountId == accountId, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.AccountId);
            }

            var friendId = UserId.Of(command.Request.FriendId);
            var friend = await dbContext.Users.FindAsync([friendId], cancellationToken: cancellationToken);

            if (friend == null)
            {
                throw new UserNotFoundException(command.Request.FriendId.ToString());
            }

            user.RemoveFriend(friendId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveFriendResult(true);
        }
    }
}
