using UserAccess.Application.Users.Commands.RemoveFriend;

namespace UserAccess.API.Endpoints
{
    public record RemoveFriendRequest(Guid UserId);
    public record RemoveFriendResponse(bool IsSuccess);
    public class RemoveFriend : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/friends/remove", async (RemoveFriendRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                RemoveFriendDto removeFriendDto = new(
                    UserId: userId,
                    FriendId: request.UserId
                    );

                var removeFriendDtoRequest = new
                {
                    Request = removeFriendDto
                };

                var command = removeFriendDtoRequest.Adapt<RemoveFriendCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<RemoveFriendResponse>();

                return Results.Ok(response);
            })
            .WithName("RemoveFriend")
            .Produces<RemoveFriendResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Remove Friend")
            .WithDescription("Remove Friend");
        }
    }
}
