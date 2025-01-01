namespace PostManagement.Domain.Events
{
    public record CommentRepliedEvent(Comment Comment, CommentId ChildComment) : IDomainEvent;
}
