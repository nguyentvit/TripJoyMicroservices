using TravelPlan.Application.Plans.Commands.EditNote;

namespace TravelPlan.API.Endpoints.Plan
{
    public record EditNoteRequest(string Note);
    public record EditNoteResponse(bool IsSuccess);
    public class EditNote : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plan/{planId}/note", async (Guid planId, EditNoteRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new EditNoteCommand(userId, planId, request.Note);

                var result = await sender.Send(command);

                var response = result.Adapt<EditNoteResponse>();

                return Results.Ok(response);
            });
        }
    }
}
