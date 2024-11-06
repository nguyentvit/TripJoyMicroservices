namespace UserAccess.Application.Dtos
{
    public record AcceptFriendRequestDto(
        string AccountId,
        Guid SenderId
        );
}
