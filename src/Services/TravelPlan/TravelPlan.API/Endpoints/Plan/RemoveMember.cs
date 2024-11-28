using TravelPlan.Application.Plans.Commands.RemoveMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record RemoveMemberResponse(bool IsSuccess);
    public class RemoveMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/plans/{planId}/members/{targetUserId}/remove", async (Guid planId, Guid targetUserId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var command = new RemoveMemberCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);
                var response = result.Adapt<RemoveMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
