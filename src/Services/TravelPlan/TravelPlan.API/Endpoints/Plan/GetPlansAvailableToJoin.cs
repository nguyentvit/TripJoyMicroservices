
using TravelPlan.Application.Plans.Queries.GetPlansAvailableToJoin;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlansAvailableToJoinResponse(PaginationResult<GetPlansAvailableToJoinDto> Plans);
    public class GetPlansAvailableToJoin : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans/available-join", async (ISender sender, IHttpContextAccessor httpContext, [AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetPlansAvailableToJoinQuery(request, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetPlansAvailableToJoinResponse>();

                return Results.Ok(response);
            });
        }
    }
}
