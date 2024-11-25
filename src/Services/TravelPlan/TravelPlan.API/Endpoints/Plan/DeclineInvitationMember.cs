
using TravelPlan.Application.Plans.Commands.DeclineInvitationMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record DeclineInvitationMemberResponse(bool IsSuccess);
    public class DeclineInvitationMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/members/decline", async (IHttpContextAccessor httpContext, ISender sender, Guid planId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new DeclineInvitationMemberCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<DeclineInvitationMemberResponse>(); 

                return Results.Ok(response);
            });
        }
    }
}
