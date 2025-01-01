using PostManagement.Application.Comments.Queries.GetReplyCommentsByCommentId;

namespace PostManagement.API.Endpoints.Comments
{
    public record GetReplyCommentsByCommentIdResponse(PaginationResult<GetReplyCommentsByCommentIdDto> Comments);
    public class GetReplyCommentsByCommentId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/comments/{commentId}/reply", async (ISender sender, [AsParameters] PaginationRequest request, Guid commentId, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetReplyCommentsByCommentIdQuery(request, commentId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetReplyCommentsByCommentIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
