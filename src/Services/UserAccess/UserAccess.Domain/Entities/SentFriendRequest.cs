namespace UserAccess.Domain.Entities
{
    public class SentFriendRequest : Entity<SendFriendRequestId>
    {
        public UserId UserReceiverId { get; private set; } = default!;
        private SentFriendRequest(SendFriendRequestId id, UserId userReceiverId)
        {
            Id = id;
            UserReceiverId = userReceiverId;
        }
        private SentFriendRequest() { }
        public static SentFriendRequest Of(UserId userReceiverId)
        {
            ArgumentNullException.ThrowIfNull(userReceiverId, nameof(userReceiverId));
            return new SentFriendRequest(SendFriendRequestId.Of(Guid.NewGuid()), userReceiverId);
        }
    }
}
