namespace PostManagement.Application.Comments.Queries.GetReplyCommentsByCommentId
{
    public class GetReplyCommentsByCommentIdHandler
        (IApplicationDbContext dbContext, IUserAccessService userService) : IQueryHandler<GetReplyCommentsByCommentIdQuery, GetReplyCommentsByCommentIdResult>
    {
        public async Task<GetReplyCommentsByCommentIdResult> Handle(GetReplyCommentsByCommentIdQuery query, CancellationToken cancellationToken)
        {
            var commentId = CommentId.Of(query.CommentId);
            var comment = await dbContext.Comments.FindAsync([commentId], cancellationToken);
            if (comment == null)
                throw new CommentNotFoundException(commentId.Value);

            var userId = UserId.Of(query.UserId);

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = comment.CommentReplyIds.Count;

            var replyComments = await dbContext.Comments
                .Where(c => c.ParentCommentId == commentId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var userIds = replyComments.Select(c => c.UserId.Value).Distinct().ToList();
            var usersInfo = await userService.GetUsersInfoAsync(userIds, cancellationToken);

            var replyCommentsDto = replyComments.Select(c =>
            {
                var userInfo = usersInfo.FirstOrDefault(u => u.UserId == c.UserId.Value);
                var commentReaction = c.CommentReactions.Select(cr => cr.Emotion).Distinct().ToList();
                var emotion = c.CommentReactions.FirstOrDefault(reaction => reaction.UserId == userId);
                return new GetReplyCommentsByCommentIdDto(
                    CommentId: c.Id.Value,
                    UserId: c.UserId.Value,
                    UserName: userInfo!.UserName,
                    Url: userInfo.Avatar,
                    Content: c.Content.Value,
                    LikeCount: c.CommentReactions.Count,
                    ReplyCount: c.CommentReplyIds.Count,
                    CreatedAt: c.CreatedAt!.Value,
                    EmotionByMe: emotion?.Emotion,
                    CommentReactionsDistinct: commentReaction.Select(e => new GetReplyCommentsByCommentIdDtoCommentReaction(e)).ToList()
                    );
            });

            return new GetReplyCommentsByCommentIdResult(new PaginationResult<GetReplyCommentsByCommentIdDto>(pageIndex, pageSize, totalCount, replyCommentsDto));
        }
    }
}
