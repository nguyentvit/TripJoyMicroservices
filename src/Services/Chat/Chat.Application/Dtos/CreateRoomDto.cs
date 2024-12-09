namespace Chat.Application.Dtos
{
    public record CreateRoomDto(Guid RoomId, bool IsNew, ChatRoomType Type, List<Guid> UserIds);
}
