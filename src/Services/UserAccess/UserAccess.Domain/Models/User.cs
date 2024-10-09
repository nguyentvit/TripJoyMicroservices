namespace UserAccess.Domain.Models
{
    public class User : Aggregate<UserId>
    {
        private readonly List<FriendId> _friendIds = new();
        public IReadOnlyList<FriendId> FriendIds => _friendIds.AsReadOnly();
        public UserName UserName { get; private set; } = default!;
        public Email EmailAddress { get; private set; } = default!;
        public PhoneNumber? Phone { get; private set; }
        public Date? DateOfBirth { get; private set; }
        public Image? Avatar { get; private set; }
        public Address? Address { get; private set; }
        public UserGender? Gender { get; private set; }
        public AccountStatus Status { get; private set; } = AccountStatus.Active;
        public static User Create(UserId id, UserName userName, Email emailAddress, PhoneNumber phone)
        {
            var user = new User
            {
                Id = id,
                UserName = userName,
                EmailAddress = emailAddress,
                Phone = phone
            };

            user.AddDomainEvent(new UserCreatedEvent(user));

            return user;
        }
        public void Update(UserName userName, PhoneNumber phone, Date dateOfBirth, Image avatar, Address address, UserGender gender)
        {
            UserName = userName;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Avatar = avatar;
            Address = address;
            Gender = gender;

            AddDomainEvent(new UserUpdatedEvent(this));
        }
        public void AddFriend(FriendId friendId)
        {
            if (!_friendIds.Contains(friendId))
            {
                _friendIds.Add(friendId);
                AddDomainEvent(new UserAddedFriendEvent(friendId, this.Id));
            }
        }
        public void RemoveFriend(FriendId friendId)
        {
            if (_friendIds.Contains(friendId))
            {
                _friendIds.Remove(friendId);
                AddDomainEvent(new UserRemovedFriendEvent(friendId, this.Id));
            }
        }
    }
}
