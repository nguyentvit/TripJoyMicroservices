namespace UserAccess.Application.Dtos
{
    public record SentFriendRequestDto(
        string AccountId, 
        Guid ReceiverId
        );
}
