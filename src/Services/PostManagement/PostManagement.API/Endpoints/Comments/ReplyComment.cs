
using PostManagement.Application.Comments.Commands.ReplyComment;

namespace PostManagement.API.Endpoints.Comments
{
    public record ReplyCommentRequest(ReplyCommentDto Comment);
    public record ReplyCommentResponse(Guid CommentId);
    public class ReplyComment : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/comments/{commentId}/reply", async (IHttpContextAccessor httpContext, ISender sender, Guid commentId, ReplyCommentRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new ReplyCommentCommand(request.Comment, userId, commentId);

                var result = await sender.Send(command);

                var response = result.Adapt<ReplyCommentResponse>();

                return Results.Ok(response);
            });
        }
    }
}
