
namespace PostManagement.Application.Posts.Queries.GetPostByPostId
{
    public class GetPostByPostIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetPostByPostIdQuery, GetPostByPostIdResult>
    {
        public async Task<GetPostByPostIdResult> Handle(GetPostByPostIdQuery query, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(query.PostId);
            var postExisted = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (postExisted == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(query.UserId);

            List<Guid> userPostedIds = [];
            userPostedIds.Add(postExisted.UserId.Value);
            var userPostedInfos = await userService.GetUsersInfoAsync(userPostedIds, cancellationToken);

            var postDto = postExisted switch
            {
                PlanPost planPost => planPost.ToGetPostDtoFromPlanPost(userId, userPostedInfos),
                Post post => post.ToGetPostDtoFromPost(userId, userPostedInfos),
                _ => throw new Exception("Exception in GetPostsByUserIdHandler")
            };

            return new GetPostByPostIdResult(postDto);

        }
    }
}
