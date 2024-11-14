using TravelPlan.Application.Plans.Commands.AddMember;

namespace TravelPlan.API.Endpoints.Plan
{
    public record AddMemberRequest(Guid UserId);
    public record AddMemberResponse(bool IsSuccess);
    public class AddMember : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/plan/{planId}/member", async (Guid planId, AddMemberRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();
                var targetUserId = request.UserId;

                var command = new AddMemberCommand(planId, userId, targetUserId);

                var result = await sender.Send(command);

                var response = result.Adapt<AddMemberResponse>();

                return Results.Ok(response);
            });
        }
    }
}
