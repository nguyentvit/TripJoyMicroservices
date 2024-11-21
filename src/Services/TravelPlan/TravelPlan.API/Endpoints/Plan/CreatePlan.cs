using TravelPlan.Application.Plans.Commands.CreatePlan;

namespace TravelPlan.API.Endpoints.Plan
{
    public record CreatePlanRequest(PlanCreateDto Plan);
    public record CreatePlanResponse(Guid Id);
    public class CreatePlan : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans", async (CreatePlanRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var command = new CreatePlanCommand(request.Plan, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<CreatePlanResponse>();

                return Results.Created($"/plan/{response.Id}", response);
            });
        }
    }
}
