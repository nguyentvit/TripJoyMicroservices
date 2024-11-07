namespace UserAccess.Application.Users.Queries.GetFriendsList
{
    public record GetFriendsListQuery(
        Guid UserId,
        PaginationRequest PaginationRequest) : IQuery<GetFriendsListResult>;
    public record GetFriendsListResult(PaginationResult<UserResponseDto> Users);
}
