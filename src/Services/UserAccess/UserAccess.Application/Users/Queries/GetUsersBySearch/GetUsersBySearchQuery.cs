namespace UserAccess.Application.Users.Queries.GetUsersBySearch
{
    public record GetUsersBySearchQuery(
        KeySearch KeySearch,
        PaginationRequest PaginationRequest) : IQuery<GetUsersBySearchResult>;
    public record GetUsersBySearchResult(PaginationResult<UserResponseDto> Users);
}
