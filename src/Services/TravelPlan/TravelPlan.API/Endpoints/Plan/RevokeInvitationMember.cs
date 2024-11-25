using TravelPlan.Application.Plans.Commands.RevokeInvitationMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record RevokeInvitationMemberResponse(bool IsSuccess);
    public class RevokeInvitationMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/members/revoke/{targetUserId}", async (Guid planId, Guid targetUserId, IHttpContextAccessor httpContext, ISender sender) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RevokeInvitationMemberCommand(userId, targetUserId, planId);

                var result = await sender.Send(command);

                var response = result.Adapt<RevokeInvitationMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
