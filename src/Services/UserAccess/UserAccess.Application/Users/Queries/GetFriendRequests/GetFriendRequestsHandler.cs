namespace UserAccess.Application.Users.Queries.GetFriendRequests
{
    public class GetFriendRequestsHandler
        (IUserRepository repository)
        : IQueryHandler<GetFriendRequestsQuery, GetFriendRequestsResult>
    {
        public async Task<GetFriendRequestsResult> Handle(GetFriendRequestsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            

            var userId = UserId.Of(query.UserId);
            var user = await repository.GetUserById(userId);

            var totalCount = user.FriendRequests.Count;

            var friendRequests = await user.ToFriendRequests(pageIndex, pageSize, repository);

            return new GetFriendRequestsResult(new PaginationResult<UserResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                friendRequests
                ));
        }
    }
}
