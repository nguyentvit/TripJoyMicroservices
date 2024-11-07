namespace UserAccess.Application.Dtos
{
    public record RevokeFriendRequestDto(
        Guid UserId,
        Guid ReceiverId
        );
}
