namespace UserAccess.Application.Users.Queries.GetUsersBySearchExternalService
{
    public record GetUsersBySearchExternalServiceQuery(PaginationRequest PaginationRequest, KeySearch KeySearch) : IQuery<GetUsersBySearchExternalServiceResult>;
    public record GetUsersBySearchExternalServiceResult(PaginationResult<UserInfoExternalServiceDto> Users);
}
