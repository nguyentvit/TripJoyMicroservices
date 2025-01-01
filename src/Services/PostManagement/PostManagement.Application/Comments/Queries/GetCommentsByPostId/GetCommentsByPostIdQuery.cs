namespace PostManagement.Application.Comments.Queries.GetCommentsByPostId
{
    public record GetCommentsByPostIdQuery(PaginationRequest PaginationRequest, Guid PostId, Guid UserId) : IQuery<GetCommentsByPostIdResult>;
    public record GetCommentsByPostIdResult(PaginationResult<GetCommentsByPostIdDto> Comments);
}
