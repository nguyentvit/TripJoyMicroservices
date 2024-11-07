namespace UserAccess.Application.Users.Commands.RevokeFriendRequest
{
    public class RevokeFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RevokeFriendRequestCommand, RevokeFriendRequestResult>
    {
        public async Task<RevokeFriendRequestResult> Handle(RevokeFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(command.Request.UserId);
            var user = await dbContext.Users.FindAsync([userId], cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.UserId);
            }

            var receiverId = UserId.Of(command.Request.ReceiverId);
            var receiver = await dbContext.Users.FindAsync([receiverId], cancellationToken: cancellationToken);

            if (receiver == null)
            {
                throw new UserNotFoundException(command.Request.ReceiverId);
            }

            user.RevokeFriendRequest(receiverId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RevokeFriendRequestResult(true);
        }
    }
}
