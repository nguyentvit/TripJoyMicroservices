using UserAccess.Application.Users.Commands.RevokeFriendRequest;

namespace UserAccess.API.Endpoints
{
    public record RevokeFriendRequestRequest(Guid UserId);
    public record RevokeFriendRequestResponse(bool IsSuccess);
    public class RevokeFriendRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/friends/revoke", async (RevokeFriendRequestRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var accountId = httpContext.HttpContext?.GetAccountIdFromJwt()!;

                RevokeFriendRequestDto revokeFriendRequestDto = new(
                    AccountId: accountId,
                    ReceiverId: request.UserId
                    );

                var revokeFriendRequestDtoRequest = new
                {
                    Request = revokeFriendRequestDto
                };

                var command = revokeFriendRequestDtoRequest.Adapt<RevokeFriendRequestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<RevokeFriendRequestResponse>();

                return Results.Ok(response);
            })
            .WithName("RevokeFriendRequest")
            .Produces<RevokeFriendRequestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Revoke Friend Request")
            .WithDescription("Revoke Friend Request");
        }
    }
}
