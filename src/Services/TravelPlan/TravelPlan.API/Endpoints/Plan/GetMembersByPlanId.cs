
using TravelPlan.Application.Plans.Queries.GetMembersByPlanId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetMembersByPlanIdResponse(PaginationResult<PlanMemberResponseDto> Members);
    public class GetMembersByPlanId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/members", async ([AsParameters] PaginationRequest request, ISender sender, IHttpContextAccessor httpContext, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetMembersByPlanIdQuery(request, userId, planId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetMembersByPlanIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
