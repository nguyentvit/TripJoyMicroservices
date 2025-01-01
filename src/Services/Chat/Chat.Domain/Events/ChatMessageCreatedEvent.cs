namespace Chat.Domain.Events
{
    public record ChatMessageCreatedEvent(ChatRoom ChatRoom, ChatMessageId ChatMessageId) : IDomainEvent;
}
