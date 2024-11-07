namespace UserAccess.Application.Users.Queries.GetInfo
{
    public class GetInfoHandler
        (IUserRepository repository)
        : IQueryHandler<GetInfoQuery, GetInfoResult>
    {
        public async Task<GetInfoResult> Handle(GetInfoQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);

            var user = await repository.GetUserById(userId);

            if (user == null)
            {
                throw new UserNotFoundException(query.UserId);
            }

            var userDto = await user.ToUserDto(repository);

            return new GetInfoResult(userDto);
        }
    }
}
