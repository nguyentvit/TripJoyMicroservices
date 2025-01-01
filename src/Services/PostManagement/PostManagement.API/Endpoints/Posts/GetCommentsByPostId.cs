
using PostManagement.Application.Comments.Queries.GetCommentsByPostId;

namespace PostManagement.API.Endpoints.Posts
{
    public record GetCommentsByPostIdResponse(PaginationResult<GetCommentsByPostIdDto> Comments);
    public class GetCommentsByPostId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/posts/{postId}/comments", async (ISender sender, [AsParameters] PaginationRequest request, Guid postId, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetCommentsByPostIdQuery(request, postId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetCommentsByPostIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
