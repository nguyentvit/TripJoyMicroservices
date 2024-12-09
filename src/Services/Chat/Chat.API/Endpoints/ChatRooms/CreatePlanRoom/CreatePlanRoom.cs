
using Chat.Application.ChatRooms.Commands.CreatePlanRoom;

namespace Chat.API.Endpoints.ChatRooms.CreatePlanRoom
{
    public record CreatePlanRoomRequest(Guid PlanId, string PlanName);
    public record CreatePlanRoomResponse(CreatePlanRoomDto Room);
    public class CreatePlanRoom : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/rooms/plan", async (ISender sender, IHttpContextAccessor httpContext, CreatePlanRoomRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CreatePlanRoomCommand(request.PlanId, userId, request.PlanName);

                var result = await sender.Send(command);

                var response = result.Adapt<CreatePlanRoomResponse>();

                return Results.Ok(response);
            });
        }
    }
}
