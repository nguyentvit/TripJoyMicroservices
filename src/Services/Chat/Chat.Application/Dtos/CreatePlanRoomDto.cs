namespace Chat.Application.Dtos
{
    public record CreatePlanRoomDto(Guid RoomId, Guid PlanId, bool IsNew, ChatRoomType Type, string ChatRoomName, List<CreatePlanRoomUserInfoDto> Users);
    public record CreatePlanRoomUserInfoDto(Guid UserId, string UserName, string? Avatar);
}
