namespace UserAccess.Application.Users.Queries.GetInfo
{
    public record GetInfoQuery(Guid UserId) : IQuery<GetInfoResult>;
    public record GetInfoResult(UserInfoDto User);
}
