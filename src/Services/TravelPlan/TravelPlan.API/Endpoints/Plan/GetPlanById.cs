using TravelPlan.Application.Plans.Queries.GetPlanById;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlanByIdResponse(PlanDetailResponseDto Plan);
    public class GetPlanById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}", async (Guid planId, ISender sender) =>
            {
                var result = await sender.Send(new GetPlanByIdQuery(planId));

                var response = result.Adapt<GetPlanByIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
