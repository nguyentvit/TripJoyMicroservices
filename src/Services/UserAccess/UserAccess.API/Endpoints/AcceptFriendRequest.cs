using UserAccess.Application.Users.Commands.AcceptFriendRequest;

namespace UserAccess.API.Endpoints
{
    public record AcceptFriendRequestRequest(Guid UserId);
    public record AcceptFriendRequestResponse(bool IsSuccess);
    public class AcceptFriendRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/friends/accept", async (AcceptFriendRequestRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var accountId = httpContext.HttpContext?.GetAccountIdFromJwt()!;

                AcceptFriendRequestDto acceptFriendRequestDto = new(
                    AccountId: accountId,
                    SenderId: request.UserId
                    );

                var acceptFriendRequestDtoRequest = new
                {
                    Request = acceptFriendRequestDto
                };

                var command = acceptFriendRequestDtoRequest.Adapt<AcceptFriendRequestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<AcceptFriendRequestResponse>();

                return Results.Ok(response);
            })
            .WithName("AcceptFriendRequest")
            .Produces<AcceptFriendRequestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Accept Friend Request")
            .WithDescription("Accept Friend Request");
        }
    }
}
