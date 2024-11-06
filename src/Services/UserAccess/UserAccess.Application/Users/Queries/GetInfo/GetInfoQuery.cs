namespace UserAccess.Application.Users.Queries.GetInfo
{
    public record GetInfoQuery(string AccountId) : IQuery<GetInfoResult>;
    public record GetInfoResult(UserDto User);
}
