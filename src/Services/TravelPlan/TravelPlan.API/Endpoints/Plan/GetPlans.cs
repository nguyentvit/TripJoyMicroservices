using TravelPlan.Application.Plans.Queries.GetPlans;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetPlansResponse(PaginationResult<PlanResponseDto> Plans);
    public class GetPlans : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/plans", async ([AsParameters] PaginationRequest request, [AsParameters] KeySearch keySearch, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var result = await sender.Send(new GetPlansQuery(userId, request, keySearch));

                var response = result.Adapt<GetPlansResponse>();

                return Results.Ok(response);
            });
        }
    }
}
