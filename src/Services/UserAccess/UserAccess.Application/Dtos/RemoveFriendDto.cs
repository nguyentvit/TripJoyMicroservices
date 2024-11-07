namespace UserAccess.Application.Dtos
{
    public record RemoveFriendDto(
        Guid UserId,
        Guid FriendId
        );
}
