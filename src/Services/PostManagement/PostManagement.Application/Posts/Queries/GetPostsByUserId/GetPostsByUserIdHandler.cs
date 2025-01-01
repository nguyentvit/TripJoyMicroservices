namespace PostManagement.Application.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetPostsByUserIdQuery, GetPostsByUserIdResult>
    {
        public async Task<GetPostsByUserIdResult> Handle(GetPostsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);
            var targetUserId = UserId.Of(query.TargetUserId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Posts.Where(p => p.UserId == targetUserId).CountAsync(cancellationToken);

            var posts = await dbContext.Posts.Where(p => p.UserId == targetUserId)
                .OrderByDescending(p => p.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var userPostedIds = posts.Select(p => p.UserId.Value).Distinct().ToList();
            var userPostedInfos = await userService.GetUsersInfoAsync(userPostedIds, cancellationToken);

            var postsDto = posts.Select(p =>
            p switch
            {
                PlanPost planPost => planPost.ToGetPostDtoFromPlanPost(userId, userPostedInfos),
                Post post => post.ToGetPostDtoFromPost(userId, userPostedInfos),
                _ => throw new Exception("Exception in GetPostsByUserIdHandler")
            }).ToList();

            return new GetPostsByUserIdResult(new PaginationResult<GetPostDto>(pageIndex, pageSize, totalCount, postsDto));

        }
    }
}
