namespace Chat.Application.ChatRooms.Commands.MarkMessageRead
{
    public record MarkMessageReadCommand(Guid UserId, Guid ChatRoomId) : ICommand<MarkMessageReadResult>;
    public record MarkMessageReadResult(bool IsSuccess);
    public class MarkMessageReadCommandValidator : AbstractValidator<MarkMessageReadCommand>
    {
        public MarkMessageReadCommandValidator()
        {

        }
    }
}
