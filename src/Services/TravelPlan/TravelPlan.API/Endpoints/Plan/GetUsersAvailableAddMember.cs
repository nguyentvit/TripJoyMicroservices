
using TravelPlan.Application.Plans.Queries.GetUsersAvailableAddMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetUsersAvailableAddMemberResponse(PaginationResult<PlanInvitationUserAvailableDto> Users);
    public class GetUsersAvailableAddMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/{planId}/planInvitations/available", async ([AsParameters] PaginationRequest request, ISender sender, [AsParameters] KeySearchUser keySearch, Guid planId, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetUsersAvailableAddMemberQuery(request, keySearch, planId, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetUsersAvailableAddMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
