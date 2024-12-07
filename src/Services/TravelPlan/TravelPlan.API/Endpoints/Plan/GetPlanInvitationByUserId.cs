
using TravelPlan.Application.Plans.Queries.GetPlanInvitationByUserId;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlanInvitationByUserIdResponse(PaginationResult<PlanInvitationByUserIdDto> PlanInvitations);
    public class GetPlanInvitationByUserId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/planInvitations", async (ISender sender, IHttpContextAccessor httpContext, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPlanInvitationByUserIdQuery(request, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlanInvitationByUserIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
