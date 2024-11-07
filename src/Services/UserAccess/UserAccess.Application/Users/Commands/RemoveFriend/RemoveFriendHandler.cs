namespace UserAccess.Application.Users.Commands.RemoveFriend
{
    public class RemoveFriendHandler
        (IApplicationDbContext dbContext)
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

            return new RemoveFriendResult(true);
        }
    }
}
