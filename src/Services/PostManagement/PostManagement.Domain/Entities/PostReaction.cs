namespace PostManagement.Domain.Entities
{
    public class PostReaction : Entity<PostReactionId>
    {
        public UserId UserId { get; private set; } = default!;
        public Emotion Emotion { get; private set; } = default!;
        private PostReaction(PostReactionId id, UserId userId, Emotion emotion)
        {
            Id = id;
            UserId = userId;
            Emotion = emotion;
        }
        public static PostReaction Of(UserId userId, Emotion emotion)
        {
            return new PostReaction(PostReactionId.Of(Guid.NewGuid()), userId, emotion);
        }
        public void SetEmotion(Emotion emotion)
        {
            Emotion = emotion;
        }
    }
}
