using TravelPlan.Application.PlanLocations.Queries.GetPlanLocationByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlanLocationByPlanIdResponse(PaginationResult<PlanLocationResponseDto> PlanLocations);
    public class GetPlanLocationByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/planLocations", async (ISender sender, Guid planId, IHttpContextAccessor httpContext, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                
                var query = new GetPlanLocationByPlanIdQuery(request, userId, planId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlanLocationByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
