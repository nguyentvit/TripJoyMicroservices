namespace UserAccess.Application.Users.Commands.SendFriendRequest
{
    public class SentFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<SentFriendRequestCommand, SendFriendRequestResult>
    {
        public async Task<SendFriendRequestResult> Handle(SentFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.Request.AccountId);
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.AccountId == accountId, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.Request.AccountId);
            }

            var receiverId = UserId.Of(command.Request.ReceiverId);
            var receiver = await dbContext.Users.FindAsync([receiverId], cancellationToken: cancellationToken);

            if (receiver == null)
            {
                throw new UserNotFoundException(command.Request.ReceiverId.ToString());
            }

            user.SendFriendRequest(receiverId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new SendFriendRequestResult(true);
        }
    }
}
