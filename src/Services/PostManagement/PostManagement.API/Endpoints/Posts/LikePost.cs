
using PostManagement.Application.Posts.Commands.LikePost;

namespace PostManagement.API.Endpoints.Posts
{
    public record LikePostRequest(LikePostDto LikePost);
    public record LikePostResponse(bool IsSuccess);
    public class LikePost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/posts/{postId}/like", async (ISender sender, IHttpContextAccessor httpContext, LikePostRequest request, Guid postId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new LikePostCommand(request.LikePost, userId, postId);

                var result = await sender.Send(command);

                var response = result.Adapt<LikePostResponse>();

                return Results.Ok(response);
            });
        }
    }
}
