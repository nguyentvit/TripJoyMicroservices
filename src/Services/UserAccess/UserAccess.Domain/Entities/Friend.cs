namespace UserAccess.Domain.Entities
{
    public class Friend : Entity<FriendId>
    {
        public UserId FriendUserId { get; private set; } = default!;
        private Friend(FriendId id, UserId friendUserId)
        {
            Id = id;
            FriendUserId = friendUserId;
        }
        [JsonConstructor]
        private Friend(UserId friendUserId)
        {
            FriendUserId = friendUserId;
        }

        private Friend() { }
        public static Friend Of(UserId friendUserId)
        {
            ArgumentNullException.ThrowIfNull(friendUserId, nameof(friendUserId));
            return new Friend(FriendId.Of(Guid.NewGuid()), friendUserId);
        }
    }
}
