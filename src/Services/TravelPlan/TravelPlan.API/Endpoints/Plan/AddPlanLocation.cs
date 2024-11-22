using TravelPlan.Application.PlanLocations.Commands.AddPlanLocation;

namespace TravelPlan.API.Endpoints.Plan
{
    public record AddPlanLocationRequest(PlanLocationAddDto PlanLocation);
    public record AddPlanLocationResponse(Guid PlanLocationId);
    public class AddPlanLocation() : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/planLocations", async (Guid planId, AddPlanLocationRequest request, IHttpContextAccessor httpContext, ISender sender) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var command = new AddPlanLocationCommand(planId, userId, request.PlanLocation);

                var result = await sender.Send(command);

                var response = result.Adapt<AddPlanLocationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
