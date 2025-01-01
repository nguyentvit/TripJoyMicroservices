using BuildingBlocks.Exceptions;

namespace Chat.Application.Exceptions
{
    public class ChatMessageNotFoundException : NotFoundException
    {
        public ChatMessageNotFoundException(Guid ChatMessageId) : base("ChatMessage ", ChatMessageId) { }
    }
}
