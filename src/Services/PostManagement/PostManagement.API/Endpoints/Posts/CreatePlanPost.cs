using PostManagement.Application.Posts.Commands.CreatePlanPost;

namespace PostManagement.API.Endpoints.Posts
{
    public record CreatePlanPostRequest(CreatePlanPostDto PlanPost);
    public record CreatePlanPostResponse(Guid PostId);
    public class CreatePlanPost : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/posts/plan", async (ISender sender, IHttpContextAccessor httpContext, [FromForm] CreatePlanPostRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new CreatePlanPostCommand(userId, request.PlanPost);

                var result = await sender.Send(command);

                var response = result.Adapt<CreatePlanPostResponse>();

                return Results.Ok(response);
            }).DisableAntiforgery();
        }
    }
}
