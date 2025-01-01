
namespace PostManagement.Application.Posts.Queries.GetPostsHomeFeed
{
    public class GetPostsHomeFeedHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetPostsHomeFeedQuery, GetPostsHomeFeedResult>
    {
        public async Task<GetPostsHomeFeedResult> Handle(GetPostsHomeFeedQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Posts.CountAsync(cancellationToken);

            var posts = await dbContext.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var userId = UserId.Of(query.UserId);

            var userPostedIds = posts.Select(p => p.UserId.Value).Distinct().ToList();
            var userPostedInfos = await userService.GetUsersInfoAsync(userPostedIds, cancellationToken);

            var postsDto = posts.Select(p =>
            p switch
            {
                PlanPost planPost => planPost.ToGetPostDtoFromPlanPost(userId, userPostedInfos),
                Post post => post.ToGetPostDtoFromPost(userId, userPostedInfos),
                _ => throw new Exception("Exception in GetPostsByUserIdHandler")
            }).ToList();

            return new GetPostsHomeFeedResult(new PaginationResult<GetPostDto>(pageIndex, pageSize, totalCount, postsDto));
        }
    }
}
