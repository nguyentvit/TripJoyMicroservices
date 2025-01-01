
using PostManagement.Application.Comments.Commands.LikeComment;

namespace PostManagement.API.Endpoints.Comments
{
    public record LikeCommentRequest(LikeCommentDto LikeComment);
    public record LikeCommentResponse(bool IsSuccess);
    public class LikeComment : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/comments/{commentId}/like", async (ISender sender, IHttpContextAccessor httpContext, LikeCommentRequest request, Guid commentId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new LikeCommentCommand(request.LikeComment, userId, commentId);

                var result = await sender.Send(command);

                var response = result.Adapt<LikeCommentResponse>();

                return Results.Ok(response);
            });
        }
    }
}
