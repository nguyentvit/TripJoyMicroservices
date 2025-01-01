
using TravelPlan.Application.Plans.Commands.CreatePlanByAI;

namespace TravelPlan.API.Endpoints.Plan
{
    public record CreatePlanByAIRequest(CreatePlanByAIDto Plan);
    public record CreatePlanByAIResponse(Guid PlanId);
    public class CreatePlanByAI : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/AI", async (ISender sender, IHttpContextAccessor httpContext, CreatePlanByAIRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CreatePlanByAICommand(request.Plan, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<CreatePlanByAIResponse>();

                return Results.Ok(response);
            });
        }
    }
}
