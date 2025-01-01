namespace PostManagement.Application.Posts.Queries.GetPostsByUserId
{
    public record GetPostsByUserIdQuery(PaginationRequest PaginationRequest, Guid TargetUserId, Guid UserId) : IQuery<GetPostsByUserIdResult>;
    public record GetPostsByUserIdResult(PaginationResult<GetPostDto> Posts);
}
