namespace Chat.Domain.Models
{
    public class ChatMessage : Aggregate<ChatMessageId>
    {
        private readonly List<ReadByRecipient> _readByRecipients = new();
        public IReadOnlyList<ReadByRecipient> ReadByRecipients => _readByRecipients.AsReadOnly();
        public Message Message { get; private set; } = default!;
        public UserId PostedByUser { get; private set; } = default!;
        public ChatRoomId ChatRoomId { get; private set; } = default!;
        private ChatMessage(ChatMessageId id, Message message, UserId postedByUser, ChatRoomId chatRoomId)
        {
            Id = id;
            Message = message;
            PostedByUser = postedByUser;
            ChatRoomId = chatRoomId;
        }
        public static ChatMessage Of(Message message, UserId postedByUser, ChatRoom chatRoom)
        {
            var chatMessage = new ChatMessage(ChatMessageId.Of(Guid.NewGuid()), message, postedByUser, chatRoom.Id);

            var readByRecipient = ReadByRecipient.Of(postedByUser);
            chatMessage._readByRecipients.Add(readByRecipient);

            chatMessage.AddDomainEvent(new ChatMessageCreatedEvent(chatRoom, chatMessage.Id));

            return chatMessage;
        }
        public void MarkMessageRead(UserId userId)
        {
            var readByRecipientExisted = _readByRecipients.FirstOrDefault(r => r.ReadByUserId == userId);
            if (readByRecipientExisted == null)
            {
                _readByRecipients.Add(ReadByRecipient.Of(userId));
            }
        }
    }
}
