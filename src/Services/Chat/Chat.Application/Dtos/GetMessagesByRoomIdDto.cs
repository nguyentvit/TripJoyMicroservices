namespace Chat.Application.Dtos
{
    public record GetMessagesByRoomIdDto(string Message, Guid PostedByUser, DateTime PostedAt);
}
