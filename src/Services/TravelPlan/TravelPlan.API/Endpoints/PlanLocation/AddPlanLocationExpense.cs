using TravelPlan.Application.PlanLocations.Commands.AddPlanLocationExpense;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record AddPlanLocationExpenseRequest(AddPlanLocationExpenseDto PlanLocationExpense);
    public record AddPlanLocationExpenseResponse(bool IsSuccess);
    public class AddPlanLocationExpense : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/planLocations/{planLocationId}/expense", async (ISender sender, Guid planLocationId, IHttpContextAccessor httpContext, AddPlanLocationExpenseRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new AddPlanLocationExpenseCommand(request.PlanLocationExpense, userId, planLocationId);

                var result = await sender.Send(command);

                var response = result.Adapt<AddPlanLocationExpenseResponse>();

                return Results.Ok(response);
            });
        }
    }
}
