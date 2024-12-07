namespace NotificationUser.SignalR.Dtos
{
    public record UserResponseDto(Guid Id, List<Guid> FriendIds, List<string> ConnectionIds);
}
