using MassTransit;

namespace UserAccess.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler
        (IApplicationDbContext dbContext,
        IPublishEndpoint publish)
        : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = CreateNewUser(command.User);

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = new BuildingBlocks.Messaging.Events.Event.UserCreatedEvent
            {
                AccountId = user.AccountId.Value,
                UserId = user.Id.Value
            };

            await publish.Publish(eventMessage, cancellationToken);

            return new CreateUserResult(user.Id.Value);
        }
        private User CreateNewUser(UserAddDto userDto)
        {
            var newUser = User.Create(
                id: UserId.Of(Guid.NewGuid()),
                userName: UserName.Of(userDto.UserName),
                emailAddress: Email.Of(userDto.Email),
                phone: PhoneNumber.Of(userDto.PhoneNumber),
                accountId: AccountId.Of(userDto.AccountId)
                );

            return newUser;
        }
    }
}
