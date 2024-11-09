namespace UserAccess.Application.Users.Queries.GetUsersBySearch
{
    public record GetUsersBySearchQuery(
        Guid MyId,
        KeySearch KeySearch,
        PaginationRequest PaginationRequest) : IQuery<GetUsersBySearchResult>;
    public record GetUsersBySearchResult(PaginationResult<UserResponseOtherDto> Users);
}
