namespace PostManagement.Domain.Entities
{
    public class CommentReaction : Entity<CommentReactionId>
    {
        public UserId UserId { get; private set; } = default!;
        public Emotion Emotion { get; private set; } = default!;
        private CommentReaction(CommentReactionId id, UserId userId, Emotion emotion)
        {
            Id = id;
            UserId = userId;
            Emotion = emotion;
        }
        public static CommentReaction Of(UserId userId, Emotion emotion)
        {
            return new CommentReaction(CommentReactionId.Of(Guid.NewGuid()), userId, emotion);
        }
        public void SetEmotion(Emotion emotion)
        {
            Emotion = emotion;
        }
    }
}
