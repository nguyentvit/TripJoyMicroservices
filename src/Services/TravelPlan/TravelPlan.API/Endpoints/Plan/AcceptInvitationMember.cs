using TravelPlan.Application.Plans.Commands.AcceptInvitationMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record AcceptInvitationMemberResponse(bool IsSuccess);
    public class AcceptInvitationMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/members/accept", async (Guid planId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new AcceptInvitationMemberCommand(planId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<AcceptInvitationMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
