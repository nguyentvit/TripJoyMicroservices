namespace UserAccess.Application.Dtos
{
    public record DeclineFriendRequestDto(
        Guid UserId, 
        Guid SenderId
        );
}
