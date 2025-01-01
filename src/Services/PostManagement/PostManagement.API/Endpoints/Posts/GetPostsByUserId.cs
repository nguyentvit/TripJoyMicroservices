
using PostManagement.Application.Posts.Queries.GetPostsByUserId;

namespace PostManagement.API.Endpoints.Posts
{
    public record GetPostsByUserIdResponse(PaginationResult<GetPostDto> Posts);
    public class GetPostsByUserId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/posts/users/{targetUserId}", async (ISender sender, Guid targetUserId, [AsParameters] PaginationRequest request, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPostsByUserIdQuery(request, targetUserId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPostsByUserIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
