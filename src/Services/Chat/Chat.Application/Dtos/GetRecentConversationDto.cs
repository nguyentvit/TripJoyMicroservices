namespace Chat.Application.Dtos
{
    public record GetRecentConversationDto(Guid RoomId, Guid UserId, string UserName, string? Avatar, string LastMessage, bool SendByMe, bool IsRead, DateTime SendAt);
}
