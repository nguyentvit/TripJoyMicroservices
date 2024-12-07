namespace UserAccess.Application.Users.Queries.GetUsersInfoExternalService
{
    public class GetUsersInfoExternalServiceHandler
        (IUserRepository repository) : IQueryHandler<GetUsersInfoExternalServiceQuery, GetUsersInfoExternalServiceResult>
    {
        public async Task<GetUsersInfoExternalServiceResult> Handle(GetUsersInfoExternalServiceQuery query, CancellationToken cancellationToken)
        {
            var userIds = query.UserIds.Select(id => UserId.Of(id)).ToList();

            List<UserInfoExternalServiceDto> userResult = new();
            foreach (var id in userIds)
            {
                var user = await repository.GetUserById(id);
                if (user != null)
                {
                    userResult.Add(new UserInfoExternalServiceDto(
                        UserId: user.Id.Value,
                        UserName: user.UserName.Value,
                        Avatar: (user.Avatar == null) ? null : user.Avatar.Url
                        ));
                }
            }

            return new GetUsersInfoExternalServiceResult(userResult);
        }
    }
}
