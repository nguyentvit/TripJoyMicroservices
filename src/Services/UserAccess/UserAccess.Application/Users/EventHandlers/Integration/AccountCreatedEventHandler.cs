using BuildingBlocks.Messaging.Events.Event;
using MassTransit;
using UserAccess.Application.Users.Commands.CreateUser;

namespace UserAccess.Application.Users.EventHandlers.Integration
{
    public class AccountCreatedEventHandler
        (ISender sender, ILogger<AccountCreatedEventHandler> logger)
        : IConsumer<AccountCreatedEvent>
    {
        public async Task Consume(ConsumeContext<AccountCreatedEvent> context)
        {
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToCreateUserCommand(context.Message);
            await sender.Send(command);

        }
        private CreateUserCommand MapToCreateUserCommand(AccountCreatedEvent message)
        {
            var userDto = new UserAddDto(
                UserName: message.Name,
                Email: message.Email,
                AccountId: message.AccountId
                );

            return new CreateUserCommand(userDto);
        }
    }
}
