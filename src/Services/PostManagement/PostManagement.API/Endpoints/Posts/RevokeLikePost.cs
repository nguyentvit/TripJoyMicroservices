
using PostManagement.Application.Posts.Commands.RevokeLikePost;

namespace PostManagement.API.Endpoints.Posts
{
    public record RevokeLikePostResponse(bool IsSuccess);
    public class RevokeLikePost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/posts/{postId}/revokeLike", async (ISender sender, IHttpContextAccessor httpContext, Guid postId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RevokeLikePostCommand(postId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<RevokeLikePostResponse>();

                return Results.Ok(response);
            });
        }
    }
}
