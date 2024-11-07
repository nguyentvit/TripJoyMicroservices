namespace UserAccess.Application.Dtos
{
    public record UserInfoDto(
        UserResponseDto Profile,
        List<UserResponseDto> Friends,
        List<UserResponseDto> FriendRequests,
        List<UserResponseDto> SentFriendRequests
        );
}
