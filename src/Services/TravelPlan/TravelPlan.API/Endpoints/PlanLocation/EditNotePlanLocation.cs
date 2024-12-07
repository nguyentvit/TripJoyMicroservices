
using TravelPlan.Application.PlanLocations.Commands.EditNotePlanLocation;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record EditNotePlanLocationRequest(string Note);
    public record EditNotePlanLocationResponse(bool IsSuccess);
    public class EditNotePlanLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/planLocations/{planLocationId}/note", async (ISender sender, IHttpContextAccessor httpContext, Guid planLocationId, EditNotePlanLocationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new EditNotePlanLocationCommand(userId, planLocationId, request.Note);

                var result = await sender.Send(command);

                var response = result.Adapt<EditNotePlanLocationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
