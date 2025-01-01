namespace PostManagement.Application.Comments.Queries.GetReplyCommentsByCommentId
{
    public record GetReplyCommentsByCommentIdQuery(PaginationRequest PaginationRequest, Guid CommentId, Guid UserId) : IQuery<GetReplyCommentsByCommentIdResult>;
    public record GetReplyCommentsByCommentIdResult(PaginationResult<GetReplyCommentsByCommentIdDto> Comments);
}
