using UserAccess.Application.Users.Queries.GetSentFriendRequests;

namespace UserAccess.API.Endpoints
{
    public record GetSentFriendRequestsResponse(PaginationResult<UserResponseDto> Users);
    public class GetSentFriendRequests : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/friends/sentFriendRequests", async([AsParameters] PaginationRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                var result = await sender.Send(new GetSentFriendRequestsQuery(userId, request));

                var response = result.Adapt<GetSentFriendRequestsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetSentFriendRequests")
            .Produces<GetSentFriendRequestsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Sent Friend Requests")
            .WithDescription("Get Sent Friend Requests");
        }
    }
}
