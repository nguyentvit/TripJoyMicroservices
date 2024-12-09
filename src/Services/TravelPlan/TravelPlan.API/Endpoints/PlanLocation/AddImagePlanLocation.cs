using TravelPlan.Application.PlanLocations.Commands.AddImagePlanLocation;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record AddImagePlanLocationRequest(IFormFile Image);
    public record AddImagePlanLocationResponse(bool IsSuccess);
    public class AddImagePlanLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/planLocations/{planLocationId}/images/add", async (IHttpContextAccessor httpContext, ISender sender, Guid planLocationId, [FromForm] AddImagePlanLocationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new AddImagePlanLocationCommand(userId, planLocationId, request.Image);

                var result = await sender.Send(command);

                var response = result.Adapt<AddImagePlanLocationResponse>();

                return Results.Ok(response);
            })
                .DisableAntiforgery();
        }
    }
}
