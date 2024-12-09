namespace Chat.Application.ChatRooms.Commands.CreateRoom
{
    public record CreateRoomCommand(Guid UserIdFirst, Guid UserIdSecond) : ICommand<CreateRoomResult>;
    public record CreateRoomResult(CreateRoomDto Room);
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.UserIdFirst)
                .NotEmpty()
                .WithMessage("UserIdFirst cannot be empty.");

            RuleFor(x => x.UserIdSecond)
                .NotEmpty()
                .WithMessage("UserIdSecond cannot be empty.");
        }
    }
}
