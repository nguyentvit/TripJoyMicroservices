namespace PostManagement.Application.Dtos
{
    public record GetProfileUserLikeByPostIdDto(Guid UserId, string UserName, string? Url);
    public record GetProfileUserLikeByPostIdCountEmotion(Emotion Emotion, int Count);
}
