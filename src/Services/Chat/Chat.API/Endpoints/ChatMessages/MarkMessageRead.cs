
using Chat.Application.ChatRooms.Commands.MarkMessageRead;

namespace Chat.API.Endpoints.ChatMessages
{
    public record MarkMessageReadResponse(bool IsSuccess);
    public class MarkMessageRead : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/rooms/{roomId}/mark-read", async (ISender sender, IHttpContextAccessor httpContext, Guid roomId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new MarkMessageReadCommand(userId, roomId);

                var result = await sender.Send(command);

                var response = result.Adapt<MarkMessageReadResponse>();

                return Results.Ok(response);
            });
        }
    }
}
