namespace Chat.Application.Dtos
{
    public record GetMessagesByRoomIdDto(string Message, Guid PostedByUser, DateTime PostedAt, bool SendByMe);
    public record GetMessagesByRoomIdMemberDto(Guid UserId, string UserName, string? Avatar);
}
