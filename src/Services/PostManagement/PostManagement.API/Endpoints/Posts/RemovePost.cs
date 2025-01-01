
using PostManagement.Application.Posts.Commands.RemovePost;

namespace PostManagement.API.Endpoints.Posts
{
    public record RemovePostResponse(bool IsSuccess);
    public class RemovePost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/posts/{postId}", async (ISender sender, IHttpContextAccessor httpContext, Guid postId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RemovePostCommand(postId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<RemovePostResponse>();

                return Results.Ok(response);
            });
        }
    }
}
