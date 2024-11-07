using UserAccess.Application.Users.Queries.GetFriendsList;

namespace UserAccess.API.Endpoints
{
    public record GetFriendsResponse(PaginationResult<UserResponseDto> Users);
    public class GetFriends : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/friends/friends", async([AsParameters] PaginationRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                var result = await sender.Send(new GetFriendsListQuery(userId, request));

                var response = result.Adapt<GetFriendsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetFriends")
            .Produces<GetFriendsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Friends")
            .WithDescription("Get Friends");
        }
    }
}
