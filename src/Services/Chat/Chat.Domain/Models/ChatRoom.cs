namespace Chat.Domain.Models
{
    public class ChatRoom : Aggregate<ChatRoomId>
    {
        private readonly List<ChatRoomMember> _members = new();
        private readonly List<ChatMessageId> _chatMessageIds = new();
        public IReadOnlyList<ChatRoomMember> Members => _members.AsReadOnly();
        public IReadOnlyList<ChatMessageId> ChatMessageIds => _chatMessageIds.AsReadOnly();
        public ChatRoomType Type { get; private set; }
        public PlanId? PlanId { get; private set; }
        public ChatRoomName? Name { get; private set; }
        private ChatRoom(ChatRoomId id, ChatRoomType type, PlanId? planId = null, ChatRoomName? name = null)
        {
            Id = id;
            Type = type;
            PlanId = planId;
            Name = name;
        }
        private ChatRoom() { }
        public static ChatRoom CreatePrivateRoom(ChatRoomMember memberFirst, ChatRoomMember memberLast)
        {
            var room = new ChatRoom(ChatRoomId.Of(Guid.NewGuid()), ChatRoomType.Private);

            room._members.Add(memberFirst);
            room._members.Add(memberLast);

            return room;
        }
        public static ChatRoom CreatePlanRoom(PlanId planId, ChatRoomName name, ChatRoomMember creator)
        {
            var room = new ChatRoom(ChatRoomId.Of(Guid.NewGuid()), ChatRoomType.Plan, planId, name);

            room._members.Add(creator);

            return room;
        }
        public void AddMember(ChatRoomMember newMember)
        {
            if (Type != ChatRoomType.Plan)
                throw new DomainException("Only room with type plan can add member");

            if (!_members.Any(m => m.MemberId == newMember.MemberId))
                _members.Add(newMember);
        }
        public void RemoveMember(UserId memberId)
        {
            if (Type != ChatRoomType.Plan)
                throw new DomainException("Only room with type plan can remove member");

            var existedMember = _members.FirstOrDefault(m => m.MemberId == memberId);
            if (existedMember == null)
                throw new DomainException("User is not a member of the room.");

            _members.Remove(existedMember);
        }
        public bool IsPrivateRoom() => Type == ChatRoomType.Private;
        public bool IsPlanRoom() => Type == ChatRoomType.Plan;
        public void AccessChatRoom(UserId userId)
        {
            if (!_members.Any(m => m.MemberId == userId))
                throw new DomainException("You don't have policy to access chat room");
        }
        public void AddChatMessageId(ChatMessageId chatMessageId)
        {
            _chatMessageIds.Add(chatMessageId);
        }
    }
}
