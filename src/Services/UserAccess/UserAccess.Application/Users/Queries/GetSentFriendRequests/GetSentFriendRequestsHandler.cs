namespace UserAccess.Application.Users.Queries.GetSentFriendRequests
{
    public class GetSentFriendRequestsHandler
        (IUserRepository repository)
        : IQueryHandler<GetSentFriendRequestsQuery, GetSentFriendRequestsResult>
    {
        public async Task<GetSentFriendRequestsResult> Handle(GetSentFriendRequestsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;


            var userId = UserId.Of(query.UserId);
            var user = await repository.GetUserById(userId);
            
            var totalCount = user.SentFriendRequests.Count;

            var sentFriendRequest = await user.ToSentFriendRequests(pageIndex, pageSize, repository);

            return new GetSentFriendRequestsResult(new PaginationResult<UserResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                sentFriendRequest
                ));
        }
    }
}
