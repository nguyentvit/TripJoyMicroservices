namespace Chat.Domain.Entities
{
    public class ChatRoomMember : Entity<ChatRoomMemberId>
    {
        public UserId MemberId { get; private set; }
        private ChatRoomMember(ChatRoomMemberId id, UserId memberId)
        {
            Id = id;
            MemberId = memberId;
        }
        private ChatRoomMember() { }
        public static ChatRoomMember Of(UserId memberId)
        {
            return new ChatRoomMember(ChatRoomMemberId.Of(Guid.NewGuid()), memberId);
        }
    }
}
