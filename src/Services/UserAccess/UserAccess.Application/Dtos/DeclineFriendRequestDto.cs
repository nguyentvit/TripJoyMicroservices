namespace UserAccess.Application.Dtos
{
    public record DeclineFriendRequestDto(
        string AccountId, 
        Guid SenderId
        );
}
