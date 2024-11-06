﻿namespace UserAccess.Application.Users.Commands.RevokeFriendRequest
{
    public class RevokeFriendRequestHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<RevokeFriendRequestCommand, RevokeFriendRequestResult>
    {
        public async Task<RevokeFriendRequestResult> Handle(RevokeFriendRequestCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.Request.AccountId);
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.AccountId == accountId, cancellationToken);

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

            user.RevokeFriendRequest(receiverId);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RevokeFriendRequestResult(true);
        }
    }
}
