
using PostManagement.Application.Comments.Commands.UpdateComment;

namespace PostManagement.API.Endpoints.Comments
{
    public record UpdateCommentRequest(UpdateCommentDto Comment);
    public record UpdateCommentResponse(bool IsSuccess);
    public class UpdateComment : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/comments/{commentId}", async (ISender sender, IHttpContextAccessor httpContext, Guid commentId, UpdateCommentRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new UpdateCommentCommand(commentId, userId, request.Comment);

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateCommentResponse>();

                return Results.Ok(response);
            });
        }
    }
}
