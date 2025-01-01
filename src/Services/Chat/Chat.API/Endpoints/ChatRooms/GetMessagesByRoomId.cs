using Chat.Application.ChatRooms.Queries.GetMessagesByRoomId;

namespace Chat.API.Endpoints.ChatRooms
{
    public record GetMessagesByRoomIdResponse(PaginationResult<GetMessagesByRoomIdDto> Messages, List<GetMessagesByRoomIdMemberDto> Members);
    public class GetMessagesByRoomId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/rooms/{roomId}/messages", async (ISender sender, IHttpContextAccessor httpContext, Guid roomId, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetMessagesByRoomIdQuery(request, roomId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetMessagesByRoomIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
