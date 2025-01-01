
namespace PostManagement.Application.Posts.Queries.GetProfileUserLikeByPostId
{
    public class GetProfileUserLikeByPostIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetProfileUserLikeByPostIdQuery, GetProfileUserLikeByPostIdResult>
    {
        public async Task<GetProfileUserLikeByPostIdResult> Handle(GetProfileUserLikeByPostIdQuery query, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(query.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            
            var emotion = query.Emotion;

            var userIds = post.PostReactions
                .Where(pr => emotion == null || pr.Emotion == emotion)
                .OrderByDescending(pr => pr.CreatedAt)
                .Select(pr => pr.UserId.Value)
                .ToList();

            var totalCount = userIds.Count;

            var emotionCount = post.PostReactions
                .GroupBy(pr => pr.Emotion)
                .Select(g => new GetProfileUserLikeByPostIdCountEmotion(g.Key, g.Count()))
                .ToList();

            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var result = userIds
                .Select(userId =>
                {
                    var userInfo = usersInfo.FirstOrDefault(u => u.UserId == userId);
                    return new GetProfileUserLikeByPostIdDto(userId, userInfo!.UserName, userInfo.Avatar);
                })
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new GetProfileUserLikeByPostIdResult(new PaginationResult<GetProfileUserLikeByPostIdDto>(pageIndex, pageSize, totalCount, result), emotionCount);


        }
    }
}
