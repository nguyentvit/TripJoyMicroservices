namespace UserAccess.Domain.Entities
{
    public class FriendRequest : Entity<FriendRequestId>
    {
        public UserId UserSenderId { get; private set; } = default!;
        
        private FriendRequest(FriendRequestId id, UserId userSenderId)
        {
            Id = id;
            UserSenderId = userSenderId;
        }
        [JsonConstructor]
        private FriendRequest(UserId userSenderId)
        {
            UserSenderId = UserSenderId;
        }
        private FriendRequest() { }
        public static FriendRequest Of(UserId userSenderId)
        {
            ArgumentNullException.ThrowIfNull(userSenderId, nameof(userSenderId));
            return new FriendRequest(FriendRequestId.Of(Guid.NewGuid()), userSenderId);
        }
    }
}
