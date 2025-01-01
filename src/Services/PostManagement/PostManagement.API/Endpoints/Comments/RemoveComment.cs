
using PostManagement.Application.Comments.Commands.RemoveComment;

namespace PostManagement.API.Endpoints.Comments
{
    public record RemoveCommentResponse(bool IsSuccess);
    public class RemoveComment : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/comments/{commentId}", async (ISender sender, IHttpContextAccessor httpContext, Guid commentId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RemoveCommentCommand(userId, commentId);

                var result = await sender.Send(command);

                var response = result.Adapt<RemoveCommentResponse>();

                return Results.Ok(response);
            });
        }
    }
}
