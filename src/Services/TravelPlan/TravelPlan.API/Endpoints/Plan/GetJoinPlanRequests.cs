
using TravelPlan.Application.Plans.Queries.GetJoinPlanRequests;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetJoinPlanRequestsResponse(PaginationResult<GetJoinPlanRequestsDto> JoinPlanRequests);
    public class GetJoinPlanRequests : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/join-request", async (ISender sender, IHttpContextAccessor httpContext, Guid planId,[AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetJoinPlanRequestsQuery(request, planId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetJoinPlanRequestsResponse>();

                return Results.Ok(response);
            });
        }
    }
}
