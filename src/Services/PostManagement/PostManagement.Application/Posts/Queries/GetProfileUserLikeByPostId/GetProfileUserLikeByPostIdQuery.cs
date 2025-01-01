namespace PostManagement.Application.Posts.Queries.GetProfileUserLikeByPostId
{
    public record GetProfileUserLikeByPostIdQuery(PaginationRequest PaginationRequest, Guid PostId, Emotion? Emotion) : IQuery<GetProfileUserLikeByPostIdResult>;
    public record GetProfileUserLikeByPostIdResult(PaginationResult<GetProfileUserLikeByPostIdDto> Users, List<GetProfileUserLikeByPostIdCountEmotion> EmotionCount);
}
