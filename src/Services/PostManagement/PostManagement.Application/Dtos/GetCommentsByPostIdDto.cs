namespace PostManagement.Application.Dtos
{
    public record GetCommentsByPostIdDto(
        Guid CommentId, 
        Guid UserId, 
        string UserName, 
        string? Url, 
        string Content, 
        int LikeCount,
        int ReplyCount,
        DateTime CreatedAt,
        Emotion? EmotionByMe,
        List<GetCommentsByPostIdDtoCommentReaction> CommentReactionsDistinct);
    public record GetCommentsByPostIdDtoCommentReaction(Emotion Emotion);
}
