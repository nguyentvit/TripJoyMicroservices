
using PostManagement.Application.Posts.Queries.GetPostByPostId;

namespace PostManagement.API.Endpoints.Posts
{
    public record GetPostByPostIdResponse(GetPostDto Post);
    public class GetPostByPostId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("posts/{postId}", async (ISender sender, IHttpContextAccessor httpContext, Guid postId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPostByPostIdQuery(userId, postId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPostByPostIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
