using UserAccess.Application.Users.Queries.GetFriendRequests;

namespace UserAccess.API.Endpoints
{
    public record GetFriendsRequestResponse(PaginationResult<UserResponseDto> Users);
    public class GetFriendRequests : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/friends/friendRequests", async ([AsParameters] PaginationRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                var result = await sender.Send(new GetFriendRequestsQuery(userId, request));

                var response = result.Adapt<GetFriendsRequestResponse>();

                return Results.Ok(response);
            })
            .WithName("GetFriendRequests")
            .Produces<GetFriendsRequestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Friend Requests")
            .WithDescription("Get Friend Requests");
        }
    }
}
