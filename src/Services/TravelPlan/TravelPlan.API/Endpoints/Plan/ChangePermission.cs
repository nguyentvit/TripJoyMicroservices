using TravelPlan.Application.Plans.Commands.ChangePermission;

namespace TravelPlan.API.Endpoints.Plan
{
    public record ChangePermissionResponse(bool IsSuccess);
    public class ChangePermission : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/plans/{planId}/members/{targetUserId}/permission", async (Guid planId, Guid targetUserId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new ChangePermissionCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);

                var response = result.Adapt<ChangePermissionResponse>();

                return Results.Ok(response);
            });
        }
    }
}
