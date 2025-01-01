using PostManagement.Application.Posts.Commands.CreatePost;

namespace PostManagement.API.Endpoints.Posts
{
    public record CreatePostRequest(CreatePostDto Post);
    public record CreatePostResponse(Guid PostId);
    public class CreatePost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/posts", async (ISender sender, IHttpContextAccessor httpContext,[FromForm] CreatePostRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CreatePostCommand(userId, request.Post);

                var result = await sender.Send(command);

                var response = result.Adapt<CreatePostResponse>();

                return Results.Ok(response);
            }).DisableAntiforgery();
        }
    }
}
