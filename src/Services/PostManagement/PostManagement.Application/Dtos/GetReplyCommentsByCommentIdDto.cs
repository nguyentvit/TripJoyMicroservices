namespace PostManagement.Application.Dtos
{
    public record GetReplyCommentsByCommentIdDto(
        Guid CommentId,
        Guid UserId,
        string UserName,
        string? Url,
        string Content,
        int LikeCount,
        int ReplyCount,
        DateTime CreatedAt,
        Emotion? EmotionByMe,
        List<GetReplyCommentsByCommentIdDtoCommentReaction> CommentReactionsDistinct);
    public record GetReplyCommentsByCommentIdDtoCommentReaction(Emotion Emotion);
}
