using UserAccess.Application.Users.Commands.SendFriendRequest;

namespace UserAccess.API.Endpoints
{
    public record SendFriendRequestRequest(Guid UserId);
    public record SendFriendRequestResponse(bool IsSuccess);
    public class SendFriendRequest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/friends/send", async (SendFriendRequestRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                SentFriendRequestDto sentFriendRequestDto = new(
                    UserId: userId,
                    ReceiverId: request.UserId
                    );

                var sentFriendRequestDtoRequest = new
                {
                    Request = sentFriendRequestDto
                };

                var command = sentFriendRequestDtoRequest.Adapt<SentFriendRequestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<SendFriendRequestResponse>();

                return Results.Ok(response);
            })
            .WithName("SendFriendRequest")
            .Produces<SendFriendRequestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Send Friend Request")
            .WithDescription("Send Friend Request");
        }
    }
}
