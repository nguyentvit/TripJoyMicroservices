namespace NotificationUser.SignalR.Models
{
    public class UserFriend
    {
        public Guid Id { get; set; } = default!;
        public Guid FriendId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public UserFriend(Guid friendId, Guid userId)
        {
            Id = Guid.NewGuid();
            FriendId = friendId;
            UserId = userId;
        }   
        private UserFriend() { }
    }
}
