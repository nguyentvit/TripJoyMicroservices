
using PostManagement.Application.Posts.Queries.GetProfileUserLikeByPostId;

namespace PostManagement.API.Endpoints.Posts
{
    public record GetProfileUserLikeByPostIdRequest(Emotion? Emotion = null);
    public record GetProfileUserLikeByPostIdResponse(PaginationResult<GetProfileUserLikeByPostIdDto> Users, List<GetProfileUserLikeByPostIdCountEmotion> EmotionCount);
    public class GetProfileUserLikeByPostId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/posts/{postId}/like", async (ISender sender, [AsParameters] PaginationRequest request, Guid postId, [AsParameters] GetProfileUserLikeByPostIdRequest emotion) =>
            {
                var query = new GetProfileUserLikeByPostIdQuery(request, postId, emotion.Emotion);

                var result = await sender.Send(query);

                var response = result.Adapt<GetProfileUserLikeByPostIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
