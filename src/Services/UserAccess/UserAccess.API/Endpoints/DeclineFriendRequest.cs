using UserAccess.Application.Users.Commands.DeclineFriendRequest;

namespace UserAccess.API.Endpoints
{
    public record DeclineFriendRequestRequest(Guid UserId);
    public record DeclineFriendRequestResponse(bool IsSuccess);
    public class DeclineFriendRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/friends/decline", async (DeclineFriendRequestRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var accountId = httpContext.HttpContext?.GetAccountIdFromJwt()!;

                DeclineFriendRequestDto declineFriendRequestDto = new(
                    AccountId: accountId,
                    SenderId: request.UserId
                    );

                var declineFriendRequestDtoRequest = new
                {
                    Request = declineFriendRequestDto
                };

                var command = declineFriendRequestDtoRequest.Adapt<DeclineFriendRequestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<DeclineFriendRequestResponse>();

                return Results.Ok(response);
            })
            .WithName("DeclineFriendRequest")
            .Produces<DeclineFriendRequestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Decline Friend Request")
            .WithDescription("Decline Friend Request");
        }
    }
}
