namespace UserAccess.Domain.Models
{
    public class User : Aggregate<UserId>
    {
        private readonly List<Friend> _friends = new();
        private readonly List<FriendRequest> _friendRequests = new();
        private readonly List<SentFriendRequest> _sentFriendRequests = new();
        public IReadOnlyList<Friend> Friends => _friends.AsReadOnly();
        public IReadOnlyList<FriendRequest> FriendRequests => _friendRequests.AsReadOnly();
        public IReadOnlyList<SentFriendRequest> SentFriendRequests => _sentFriendRequests.AsReadOnly();
        public UserName UserName { get; private set; } = default!;
        public Email EmailAddress { get; private set; } = default!;
        public AccountId AccountId { get; private set; } = default!;
        public PhoneNumber Phone { get; private set; } = default!;
        public Date? DateOfBirth { get; private set; }
        public Image? Avatar { get; private set; }
        public Address? Address { get; private set; }
        public UserGender? Gender { get; private set; }
        public AccountStatus Status { get; private set; } = AccountStatus.Active;
        private User() { }
        
        private User(UserId id,UserName userName, Email emailAddress, PhoneNumber phone, AccountId accountId)
        {
            Id = id;
            UserName = userName;
            EmailAddress = emailAddress;
            Phone = phone;
            AccountId = accountId;
        }
        [JsonConstructor]
        private User(UserId id,
            UserName userName,
            Email emailAddress,
            PhoneNumber phone,
            AccountId accountId,
            Date? dateOfBirth,
            Image? avatar,
            Address? address,
            UserGender? gender,
            AccountStatus status,
            List<Friend> friends,
            List<FriendRequest> friendRequests,
            List<SentFriendRequest> sentFriendRequests)
        {
            Id = id;
            UserName = userName;
            EmailAddress = emailAddress;
            Phone = phone;
            AccountId = accountId;
            DateOfBirth = dateOfBirth;
            Avatar = avatar;
            Address = address;
            Gender = gender;
            Status = status;
            _friends = friends ?? new List<Friend>();
            _friendRequests = friendRequests ?? new List<FriendRequest>();
            _sentFriendRequests = sentFriendRequests ?? new List<SentFriendRequest>();
        }
        public static User Create(UserId id, UserName userName, Email emailAddress, PhoneNumber phone, AccountId accountId)
        {
            var user = new User(id, userName, emailAddress, phone, accountId);

            user.AddDomainEvent(new UserCreatedEvent(user));

            return user;
        }
        public void Update(UserName userName, PhoneNumber phone, Date dateOfBirth, Image avatar, Address address, UserGender? gender)
        {
            UserName = userName;
            Phone = phone;

            if (dateOfBirth != null)
            {
                DateOfBirth = dateOfBirth;
            }

            if (avatar != null)
            {
                Avatar = avatar;
            }

            if (gender != null)
            {
                Gender = gender;
            }

            if (address != null)
            {
                Address = address;
            }

            AddDomainEvent(new UserUpdatedEvent(this));
        }

        public void SendFriendRequest(UserId receiverId)
        {
            if (receiverId == Id)
            {
                throw new DomainException("Cannot send a friend request to yourself.");
            }

            if (_friends.Any(f => f.FriendUserId == receiverId))
            {
                throw new DomainException("Already friends with this user.");
            }

            if (_sentFriendRequests.Any(r => r.UserReceiverId == receiverId))
            {
                throw new DomainException("Friend request already sent to this user.");
            }

            var sentFriendRequest = SentFriendRequest.Of(receiverId);
            _sentFriendRequests.Add(sentFriendRequest);

            AddDomainEvent(new UserSentFriendRequestEvent(this, receiverId));
        }

        public void ReceiveFriendRequest(UserId senderId)
        {
            if (_friends.Any(f => f.FriendUserId == senderId))
            {
                throw new DomainException("Already friends with this user.");
            }

            if (_friendRequests.Any(fr => fr.UserSenderId == senderId))
            {
                throw new DomainException("Friend request already receive from this user");
            }

            var friendRequest = FriendRequest.Of(senderId);
            _friendRequests.Add(friendRequest);
        }

        public void AcceptFriendRequest(UserId senderId)
        {
            var friendRequest = _friendRequests.FirstOrDefault(fr => fr.UserSenderId == senderId);

            if (friendRequest == null)
            {
                throw new DomainException("No friend request found from this user.");
            }

            if (_friends.Any(f => f.FriendUserId == senderId))
            {
                throw new DomainException("Already friends with this user");
            }

            var friend = Friend.Of(senderId);
            _friends.Add(friend);

            _friendRequests.Remove(friendRequest);

            AddDomainEvent(new UserAcceptFriendRequestEvent(this, senderId));
        }

        public void ReceiveAcceptFriendRequest(UserId receiverId)
        {
            var sentFriendRequest = _sentFriendRequests.FirstOrDefault(sfr => sfr.UserReceiverId == receiverId);

            if (sentFriendRequest == null)
            {
                throw new DomainException("No friend request sent to this users.");
            }

            if (_friends.Any(f => f.FriendUserId == receiverId))
            {
                throw new DomainException("Already friends with this user");
            }

            var friend = Friend.Of(receiverId);
            _friends.Add(friend);

            _sentFriendRequests.Remove(sentFriendRequest);
        }

        public void DeclineFriendRequest(UserId senderId)
        {
            var friendRequest = _friendRequests.FirstOrDefault(fr => fr.UserSenderId == senderId);

            if (friendRequest == null)
            {
                throw new DomainException("No friend request found from this user.");
            }

            if (_friends.Any(f => f.FriendUserId == senderId))
            {
                throw new DomainException("Already friends with this user");
            }

            _friendRequests.Remove(friendRequest);

            AddDomainEvent(new UserDeclineFriendRequestEvent(this, senderId));
        }

        public void ReceiveDeclineFriendRequest(UserId receiverId)
        {
            var sentFriendRequest = _sentFriendRequests.FirstOrDefault(sfr => sfr.UserReceiverId == receiverId);

            if (sentFriendRequest == null)
            {
                throw new DomainException("No friend request sent to this users.");
            }

            if (_friends.Any(f => f.FriendUserId == receiverId))
            {
                throw new DomainException("Already friends with this user");
            }

            _sentFriendRequests.Remove(sentFriendRequest);
        }

        public void RemoveFriend(UserId friendId, bool Sender = true)
        {
            var friend = _friends.FirstOrDefault(f => f.FriendUserId == friendId);

            if (friend == null)
            {
                throw new DomainException("This user is not in your friend list.");
            }

            _friends.Remove(friend);

            if (Sender)
            {
                AddDomainEvent(new UserRemoveFriendEvent(this, friendId));
            }
        }

        public void RevokeFriendRequest(UserId receiverId)
        {
            if (receiverId == Id)
            {
                throw new DomainException("Cannot revoke a friend request to yourself.");
            }

            var sentFriendRequest = _sentFriendRequests.FirstOrDefault(r => r.UserReceiverId == receiverId);

            if (sentFriendRequest == null)
            {
                throw new DomainException("No friend request found to this user.");
            }

            _sentFriendRequests.Remove(sentFriendRequest);

            AddDomainEvent(new UserRevokeFriendRequestEvent(this, receiverId));
        }

        public void ReceiveRevokeFriendRequest(UserId senderId)
        {
            var friendRequest = _friendRequests.FirstOrDefault(fr => fr.UserSenderId == senderId);

            if (friendRequest == null)
            {
                throw new DomainException("No friend request from this user to revoke.");
            }

            _friendRequests.Remove(friendRequest);
        }
    }
}
