using TravelPlan.Application.Plans.Commands.InviteMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record InviteMemberResponse(bool IsSuccess);
    public class InviteMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plans/{planId}/members/invite/{targetUserId}", async (Guid planId, Guid targetUserId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new InviteMemberCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);

                var response = result.Adapt<InviteMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
