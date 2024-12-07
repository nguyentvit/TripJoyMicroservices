namespace UserAccess.Application.Users.Queries.GetUsersInfoExternalService
{
    public record GetUsersInfoExternalServiceQuery(List<Guid> UserIds) : IQuery<GetUsersInfoExternalServiceResult>;
    public record GetUsersInfoExternalServiceResult(List<UserInfoExternalServiceDto> UsersInfo);
}
