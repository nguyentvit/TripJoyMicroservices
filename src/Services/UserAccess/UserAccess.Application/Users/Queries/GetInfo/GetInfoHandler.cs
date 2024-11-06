namespace UserAccess.Application.Users.Queries.GetInfo
{
    public class GetInfoHandler
        (IUserRepository repository)
        : IQueryHandler<GetInfoQuery, GetInfoResult>
    {
        public async Task<GetInfoResult> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(request.AccountId);

            var user = await repository.Users.FirstOrDefaultAsync(u => u.AccountId == accountId);

            if (user == null)
            {
                throw new UserNotFoundException(request.AccountId);
            }

            var userDto = user.ToUserDto();

            return new GetInfoResult(userDto);
        }
    }
}
