namespace UserAccess.Application.Dtos
{
    public record RevokeFriendRequestDto(
        string AccountId,
        Guid ReceiverId
        );
}
