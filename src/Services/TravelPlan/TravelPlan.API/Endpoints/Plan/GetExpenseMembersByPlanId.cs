using TravelPlan.Application.Plans.Queries.GetExpenseMembersByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetExpenseMembersByPlanIdResponse(PaginationResult<PlanExpenseMembersResponseDto> Members);
    public class GetExpenseMembersByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/expense/members", async (IHttpContextAccessor httpContext, ISender sender, Guid planId, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetExpenseMembersByPlanIdQuery(request, userId, planId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetExpenseMembersByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
