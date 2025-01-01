
namespace PostManagement.Application.Comments.Queries.GetCommentsByPostId
{
    public class GetCommentsByPostIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetCommentsByPostIdQuery, GetCommentsByPostIdResult>
    {
        public async Task<GetCommentsByPostIdResult> Handle(GetCommentsByPostIdQuery query, CancellationToken cancellationToken)
        {
            var postId = PostId.Of(query.PostId);
            var post = await dbContext.Posts.FindAsync([postId], cancellationToken);
            if (post == null)
                throw new PostNotFoundException(postId.Value);

            var userId = UserId.Of(query.UserId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Comments.Where(c => c.PostId == postId && c.ParentCommentId == null).CountAsync(cancellationToken);

            var comments = await dbContext.Comments
                .Where(c => c.PostId == postId && c.ParentCommentId == null)
                .OrderByDescending(c => c.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var userIds = comments.Select(c => c.UserId.Value).Distinct().ToList();

            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var commentsDto = comments.Select(c =>
            {
                var userInfo = usersInfo.FirstOrDefault(u => u.UserId == c.UserId.Value);
                var commentReactionsDistinct = c.CommentReactions.Select(c => c.Emotion).Distinct().ToList();
                var emotion = c.CommentReactions.FirstOrDefault(reaction => reaction.UserId == userId);
                return new GetCommentsByPostIdDto(
                    CommentId: c.Id.Value,
                    UserId: c.UserId.Value,
                    UserName: userInfo!.UserName,
                    Url: userInfo.Avatar,
                    Content: c.Content.Value,
                    LikeCount: c.CommentReactions.Count,
                    ReplyCount: c.CommentReplyIds.Count,
                    CreatedAt: c.CreatedAt!.Value,
                    EmotionByMe: emotion?.Emotion,
                    CommentReactionsDistinct: commentReactionsDistinct.Select(emotion => new GetCommentsByPostIdDtoCommentReaction(emotion)).ToList()
                    );
            });

            return new GetCommentsByPostIdResult(new PaginationResult<GetCommentsByPostIdDto>(pageIndex, pageSize, totalCount, commentsDto));

        }
    }
}
