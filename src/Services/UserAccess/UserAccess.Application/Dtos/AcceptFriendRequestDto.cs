namespace UserAccess.Application.Dtos
{
    public record AcceptFriendRequestDto(
        Guid UserId,
        Guid SenderId
        );
}
