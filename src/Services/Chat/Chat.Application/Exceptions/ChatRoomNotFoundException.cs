using BuildingBlocks.Exceptions;

namespace Chat.Application.Exceptions
{
    public class ChatRoomNotFoundException : NotFoundException
    {
        public ChatRoomNotFoundException(Guid ChatRoomId) : base("ChatRoom", ChatRoomId) { }
    }
}
