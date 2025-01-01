using TravelPlan.Application.PlanLocations.Queries.GetPlanLocationById;

namespace TravelPlan.API.Endpoints.PlanLocation
{
    public record GetPlanLocationByIdResponse(PlanLocationResponseDto PlanLocation);
    public class GetPlanLocationById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/planLocations/{planLocationId}", async (ISender sender, IHttpContextAccessor httpContext, Guid planLocationId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPlanLocationByIdQuery(planLocationId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlanLocationByIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
