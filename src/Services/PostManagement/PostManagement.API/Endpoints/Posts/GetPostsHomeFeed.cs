using PostManagement.Application.Posts.Queries.GetPostsHomeFeed;

namespace PostManagement.API.Endpoints.Posts
{
    public record GetPostsHomeFeedResponse(PaginationResult<GetPostDto> Posts);
    public class GetPostsHomeFeed : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/posts/homefeed", async (ISender sender, [AsParameters] PaginationRequest request, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPostsHomeFeedQuery(request, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPostsHomeFeedResponse>();

                return Results.Ok(response);
            });
        }
    }
}
