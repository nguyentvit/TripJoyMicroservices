namespace UserAccess.Application.Dtos
{
    public record SentFriendRequestDto(
        Guid UserId, 
        Guid ReceiverId
        );
}
