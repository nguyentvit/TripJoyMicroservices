namespace Chat.Domain.Entities
{
    public class ChatMessage : Entity<ChatMessageId>
    {
        public Message Message { get; private set; }
        public UserId PostedByUser { get; private set; }
        private ChatMessage(ChatMessageId id, Message message, UserId postedByUser)
        {
            Id = id;
            Message = message;
            PostedByUser = postedByUser;
        }
        private ChatMessage() { }
        public static ChatMessage Of(Message message, UserId postedByUser)
        {
            var chatMessage = new ChatMessage(ChatMessageId.Of(Guid.NewGuid()), message, postedByUser);
            return chatMessage;
        }
    }
}
