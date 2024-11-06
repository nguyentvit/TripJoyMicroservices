namespace UserAccess.Application.Dtos
{
    public record RemoveFriendDto(
        string AccountId,
        Guid FriendId
        );
}
