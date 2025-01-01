namespace Chat.Application.ChatRooms.EventHandlers
{
    public class ChatMessageCreatedEventHandler : IDomainEventHandler<ChatMessageCreatedEvent>
    {
        public Task Handle(ChatMessageCreatedEvent notification, CancellationToken cancellationToken)
        {
            var chatRoom = notification.ChatRoom;
            var chatMessageId = notification.ChatMessageId;
            chatRoom.AddChatMessageId(chatMessageId);
            return Task.CompletedTask;
        }
    }
}
