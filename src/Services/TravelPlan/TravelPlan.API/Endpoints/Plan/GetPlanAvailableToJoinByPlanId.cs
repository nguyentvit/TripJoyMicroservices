
using TravelPlan.Application.Plans.Queries.GetPlanAvailableToJoinByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlanAvailableToJoinByPlanIdResponse(PaginationResult<GetPlanAvailableToJoinByPlanIdDto> PlanLocations, GetPlanAvailableToJoinByPlanIdDtoPlan Plan, GetPlanAvailableToJoinByPlanIdDtoPlanLeadUser LeadUser);
    public class GetPlanAvailableToJoinByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/available-join", async (ISender sender, IHttpContextAccessor httpContext, Guid planId,[AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPlanAvailableToJoinByPlanIdQuery(userId, planId, request);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlanAvailableToJoinByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
