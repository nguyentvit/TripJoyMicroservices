namespace UserAccess.Application.Users.Commands.SendFriendRequest
{
    public class SentFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<SentFriendRequestCommand, SendFriendRequestResult>
    {
        public async Task<SendFriendRequestResult> Handle(SentFriendRequestCommand command, CancellationToken cancellationToken)
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

            user.SendFriendRequest(receiverId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new SendFriendRequestResult(true);
        }
    }
}
