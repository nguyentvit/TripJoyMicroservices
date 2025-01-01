
using PostManagement.Application.Posts.Commands.UpdatePost;

namespace PostManagement.API.Endpoints.Posts
{
    public record UpdatePostRequest(UpdatePostDto Post);
    public record UpdatePostResponse(bool IsSuccess);
    public class UpdatePost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/posts/{postId}", async (ISender sender, IHttpContextAccessor httpContext, [FromForm] UpdatePostRequest request, Guid postId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new UpdatePostCommand(userId, postId, request.Post);

                var result = await sender.Send(command);

                var response = result.Adapt<UpdatePostResponse>();

                return Results.Ok(response);
            }).DisableAntiforgery();
        }
    }
}
