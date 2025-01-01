
using PostManagement.Application.Posts.Commands.CommentPost;

namespace PostManagement.API.Endpoints.Posts
{
    public record CommentPostRequest(CommentPostDto Comment);
    public record CommentPostResponse(Guid CommentId);
    public class CommentPost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/posts/{postId}/comments", async (ISender sender, IHttpContextAccessor httpContext, Guid postId, CommentPostRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CommentPostCommand(userId, postId, request.Comment);

                var result = await sender.Send(command);

                var response = result.Adapt<CommentPostResponse>();

                return Results.Ok(response);
            });
        }
    }
}
