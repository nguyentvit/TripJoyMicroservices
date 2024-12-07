
namespace NotificationUser.SignalR.Users.Commands.RemoveFriend
{
    public record RemoveFriendCommand(Guid UserIdFirst, Guid UserIdSecond) : ICommand<RemoveFriendResult>;
    public record RemoveFriendResult(bool IsSuccess);
    public class RemoveFriendHandler
        (IUserRepository repository) : ICommandHandler<RemoveFriendCommand, RemoveFriendResult>
    {
        public async Task<RemoveFriendResult> Handle(RemoveFriendCommand command, CancellationToken cancellationToken)
        {
            var userIdFirst = command.UserIdFirst;
            var userIdSecond = command.UserIdSecond;

            await repository.RemoveFriend(userIdFirst, userIdSecond, cancellationToken);

            return new RemoveFriendResult(true);
        }
    }
}
