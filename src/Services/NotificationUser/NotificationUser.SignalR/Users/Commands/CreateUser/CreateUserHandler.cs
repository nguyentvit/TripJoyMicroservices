namespace NotificationUser.SignalR.Users.Commands.CreateUser
{
    public record CreateUserCommand(Guid UserId) : ICommand<CreateUserResult>;
    public record CreateUserResult(bool IsSuccess);
    public class CreateUserHandler
        (IUserRepository repository) : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.UserId);
            await repository.CreateUser(user, cancellationToken);
            return new CreateUserResult(true);
        }
    }
}
