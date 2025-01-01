namespace PostManagement.Domain.Events
{
    public record CommentCreatedEvent(Post Post, CommentId CommentId) : IDomainEvent;
}
