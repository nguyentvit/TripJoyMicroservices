namespace UserAccess.Application.Users.Queries.GetFriendRequests
{
    public record GetFriendRequestsQuery(
        Guid UserId, 
        PaginationRequest PaginationRequest) : IQuery<GetFriendRequestsResult>;
    public record GetFriendRequestsResult(PaginationResult<UserResponseDto> Users);
}
