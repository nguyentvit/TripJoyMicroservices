
namespace NotificationUser.SignalR.Users.Commands.AddFriend
{
    public record AddFriendCommand(Guid UserIdFirst, Guid UserIdSecond) : ICommand<AddFriendResult>;
    public record AddFriendResult(bool IsSuccess);
    public class AddFriendHandler
        (IUserRepository repository) : ICommandHandler<AddFriendCommand, AddFriendResult>
    {
        public async Task<AddFriendResult> Handle(AddFriendCommand command, CancellationToken cancellationToken)
        {
            await repository.AddFriend(command.UserIdFirst, command.UserIdSecond);
            return new AddFriendResult(true);
        }
    }
}
