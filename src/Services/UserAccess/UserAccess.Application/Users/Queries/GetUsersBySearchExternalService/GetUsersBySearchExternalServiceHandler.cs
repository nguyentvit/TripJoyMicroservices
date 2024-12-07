
namespace UserAccess.Application.Users.Queries.GetUsersBySearchExternalService
{
    public class GetUsersBySearchExternalServiceHandler
        (IUserRepository repository) : IQueryHandler<GetUsersBySearchExternalServiceQuery, GetUsersBySearchExternalServiceResult>
    {
        public async Task<GetUsersBySearchExternalServiceResult> Handle(GetUsersBySearchExternalServiceQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

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

            var usersResponse = users.Select(u => new UserInfoExternalServiceDto(
                UserId: u.Id.Value,
                UserName: u.UserName.Value,
                Avatar: (u.Avatar) == null ? null : u.Avatar.Url))
                .ToList();

            return new GetUsersBySearchExternalServiceResult(new PaginationResult<UserInfoExternalServiceDto>(pageIndex, pageSize, totalCount, usersResponse));
        }
    }
}
