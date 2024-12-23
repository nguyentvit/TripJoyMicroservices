﻿namespace UserAccess.Application.Users.Queries.GetUsersBySearch
{
    public class GetUsersBySearchHandler
        (IUserRepository repository)
        : IQueryHandler<GetUsersBySearchQuery, GetUsersBySearchResult>
    {
        public async Task<GetUsersBySearchResult> Handle(GetUsersBySearchQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var myId = UserId.Of(query.MyId);

            var keyNameSearch = query.KeySearch.Name;

            var users = await repository.Users
                .Where(user => user.UserName.Value.ToLower().StartsWith(keyNameSearch.ToLower()))
                .OrderBy(user => user.UserName.Value)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var totalCount = await repository.Users
                .Where(user => user.UserName.Value.ToLower().StartsWith(keyNameSearch.ToLower()))
                .LongCountAsync(cancellationToken);

            var usersResponse = users.Select(u => u.ToUserProfileOtherDto(myId)).ToList();

            return new GetUsersBySearchResult(new PaginationResult<UserResponseOtherDto>(
                pageIndex,
                pageSize,
                totalCount,
                usersResponse
                ));

        }
    }
}
