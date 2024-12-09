namespace Chat.Application.ChatRooms.Commands.PostMessage
{
    public record PostMessageCommand(Guid RoomId, Guid UserId, string Message) : ICommand<PostMessageResult>;
    public record PostMessageResult(bool IsSuccess);
    public class PostMessageCommandValidator : AbstractValidator<PostMessageCommand>
    {
        public PostMessageCommandValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty().WithMessage("RoomId is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message cannot be empty.");
        }
    }
}
