namespace Chat.API.Endpoints.ChatRooms.ChatRoomPrivate
{
    public record CreateRoomRequest(Guid UserId);
    public record CreateRoomResponse(CreateRoomDto Room);
    public class CreateRoom : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/rooms/private", async (ISender sender, IHttpContextAccessor httpContext, CreateRoomRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CreateRoomCommand(userId, request.UserId);

                var result = await sender.Send(command);

                var response = result.Adapt<CreateRoomResponse>();

                return Results.Ok(response);
            });
        }
    }
}
