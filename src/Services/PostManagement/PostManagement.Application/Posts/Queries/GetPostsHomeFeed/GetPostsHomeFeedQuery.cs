namespace PostManagement.Application.Posts.Queries.GetPostsHomeFeed
{
    public record GetPostsHomeFeedQuery(PaginationRequest PaginationRequest, Guid UserId) : IQuery<GetPostsHomeFeedResult>;
    public record GetPostsHomeFeedResult(PaginationResult<GetPostDto> Posts);
}
