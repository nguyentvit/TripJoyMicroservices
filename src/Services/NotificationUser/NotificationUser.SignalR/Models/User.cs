namespace NotificationUser.SignalR.Models
{
    public class User
    {
        public Guid Id { get; set; } = default!;
        public ICollection<UserFriend> UserFriends { get; } = new List<UserFriend>();
        public User(Guid id)
        {
            Id = id;
        }
        private User() { }
    }
}
