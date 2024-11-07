namespace UserAccess.Application.Users.Queries.GetFriendsList
{
    public class GetFriendsListHandler
        (IUserRepository repository)
        : IQueryHandler<GetFriendsListQuery, GetFriendsListResult>
    {
        public async Task<GetFriendsListResult> Handle(GetFriendsListQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var userId = UserId.Of(query.UserId);
            var user = await repository.GetUserById(userId);

            var totalCount = user.Friends.Count;

            var friends = await user.ToFriends(pageIndex, pageSize, repository);

            return new GetFriendsListResult(new PaginationResult<UserResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                friends
                ));
        }
    }
}
