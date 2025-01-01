
using PostManagement.Application.Comments.Commands.RevokeLikeComment;

namespace PostManagement.API.Endpoints.Comments
{
    public record RevokeLikeCommentResponse(bool IsSuccess);
    public class RevokeLikeComment : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/comments/{commentId}/revokeLike", async (ISender sender, IHttpContextAccessor httpContext, Guid commentId) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var command = new RevokeLikeCommentCommand(commentId, userId);

                var result = await sender.Send(command);

                var response = result.Adapt<RevokeLikeCommentResponse>();

                return Results.Ok(response);
            });
        }
    }
}
