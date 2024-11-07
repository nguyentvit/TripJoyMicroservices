namespace UserAccess.Application.Users.Queries.GetSentFriendRequests
{
    public record GetSentFriendRequestsQuery(
        Guid UserId,
        PaginationRequest PaginationRequest) : IQuery<GetSentFriendRequestsResult>;
    public record GetSentFriendRequestsResult(PaginationResult<UserResponseDto> Users);
}
