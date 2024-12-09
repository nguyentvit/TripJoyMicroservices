
using Chat.Application.ChatRooms.Commands.PostMessage;

namespace Chat.API.Endpoints.ChatRooms
{
    public record PostMessageRequest(string Message);
    public record PostMessageResponse(bool IsSuccess);
    public class PostMessage : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/rooms/{roomId}/messages", async (ISender sender, IHttpContextAccessor httpContext, Guid roomId, PostMessageRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new PostMessageCommand(roomId, userId, request.Message);

                var result = await sender.Send(command);

                var response = result.Adapt<PostMessageResponse>();

                return Results.Ok(response);
            });
        }
    }
}
