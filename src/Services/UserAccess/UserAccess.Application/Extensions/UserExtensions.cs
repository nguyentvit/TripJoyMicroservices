namespace UserAccess.Application.Extensions
{
    public static class UserExtensions
    {
        public static async Task<UserInfoDto> ToUserDto(this User user, IUserRepository repository)
        {
            return await DtoFromUser(user, repository);
        }
        public static UserResponseDto ToUserProfileDto(this User user)
        {
            return ProfileFromUser(user);
        }
        public static UserResponseOtherDto ToUserProfileOtherDto(this User user, UserId myId)
        {
            return ProfileOtherFromUser(user, myId);
        }
        public static async Task<List<UserResponseDto>> ToFriendRequests(this User user, int PageIndex, int PageSize, IUserRepository repository)
        {
            var friendRequestIds = user.FriendRequests
                .OrderByDescending(fr => fr.CreatedAt)
                .Select(fr => fr.UserSenderId)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToList();
            List<UserResponseDto> friendRequests = new();

            foreach (var userId in friendRequestIds)
            {
                var friendRequest = await repository.GetUserById(userId);
                if (friendRequest == null)
                    throw new UserNotFoundException(userId.Value);
                friendRequests.Add(ProfileFromUser(friendRequest));
            }

            return friendRequests;
        }
        public static async Task<List<UserResponseDto>> ToSentFriendRequests(this User user, int PageIndex, int PageSize, IUserRepository repository)
        {
            var sentFriendRequestIds = user.SentFriendRequests
                .OrderByDescending(sfr => sfr.CreatedAt)
                .Select(sfr => sfr.UserReceiverId)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToList();

            List<UserResponseDto> sentFriendRequests = new();

            foreach (var userId in sentFriendRequestIds)
            {
                var sentFriendRequest = await repository.GetUserById(userId);
                if (sentFriendRequest == null)
                    throw new UserNotFoundException(userId.Value);
                sentFriendRequests.Add(ProfileFromUser(sentFriendRequest));
            }

            return sentFriendRequests;
        }
        public static async Task<List<UserResponseDto>> ToFriends(this User user, int PageIndex, int PageSize, IUserRepository repository)
        {
            var friendIds = user.Friends
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => f.FriendUserId)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToList();

            List<UserResponseDto> friends = new();

            foreach (var userId in friendIds)
            {
                var friend = await repository.GetUserById(userId);
                if (friend == null)
                    throw new UserNotFoundException(userId.Value);
                friends.Add(ProfileFromUser(friend));
            }

            return friends;
        }
        private static async Task<UserInfoDto> DtoFromUser(User user, IUserRepository repository)
        {
            List<UserId> FriendIds = user.Friends.Select(f => f.FriendUserId).ToList();
            List<UserId> FriendRequestIds = user.FriendRequests.Select(fr => fr.UserSenderId).ToList();
            List<UserId> SentFriendRequestIds = user.SentFriendRequests.Select(sfr => sfr.UserReceiverId).ToList();

            List<UserResponseDto> Friends = new();
            List<UserResponseDto> FriendRequests = new();
            List<UserResponseDto> SentFriendRequests = new();

            foreach (UserId userId in FriendIds)
            {
                var friend = await repository.GetUserById(userId);
                if (friend == null)
                    throw new UserNotFoundException(userId.Value);
                Friends.Add(ProfileFromUser(friend));
            }

            foreach (UserId userId in FriendRequestIds)
            {
                var friend = await repository.GetUserById(userId);
                if (friend == null)
                    throw new UserNotFoundException(userId.Value);
                FriendRequests.Add(ProfileFromUser(friend));
            }

            foreach (UserId userId in SentFriendRequestIds)
            {
                var friend = await repository.GetUserById(userId);
                if (friend == null)
                    throw new UserNotFoundException(userId.Value);
                SentFriendRequests.Add(ProfileFromUser(friend));
            }

            return new UserInfoDto(
                Profile: ProfileFromUser(user),
                Friends: Friends,
                FriendRequests: FriendRequests,
                SentFriendRequests: SentFriendRequests
                );
        }
        private static UserResponseDto ProfileFromUser(User user)
        {
            return new UserResponseDto(
                Id: user.Id.Value,
                UserName: user.UserName.Value,
                Email: user.EmailAddress.Value,
                PhoneNumber: (user.Phone != null) ? user.Phone.Value : null,
                DateOfBirth: (user.DateOfBirth != null) ? user.DateOfBirth.Value.ToString() : null,
                Avatar: (user.Avatar != null) ? new ImageDto(user.Avatar.Url, user.Avatar.Format) : null,
                Address: (user.Address != null) ? new AddressDto(user.Address.District, user.Address.Ward, user.Address.Province, user.Address.Country) : null,
                Gender: (user.Gender != null) ? user.Gender : null
                );
        }
        private static UserResponseOtherDto ProfileOtherFromUser(User user, UserId myId)
        {
            var friendshipStatus = GetFriendshipStatus(user, myId);

            return new UserResponseOtherDto(
                Id: user.Id.Value,
                UserName: user.UserName.Value,
                Email: user.EmailAddress.Value,
                PhoneNumber: (user.Phone != null) ? user.Phone.Value : null,
                DateOfBirth: (user.DateOfBirth != null) ? user.DateOfBirth.Value.ToString() : null,
                Avatar: (user.Avatar != null) ? new ImageDto(user.Avatar.Url, user.Avatar.Format) : null,
                Address: (user.Address != null) ? new AddressDto(user.Address.District, user.Address.Ward, user.Address.Province, user.Address.Country) : null,
                Gender: (user.Gender != null) ? user.Gender : null,
                Status: friendshipStatus
                );
        }

        private static FriendshipStatus GetFriendshipStatus(User user, UserId myId)
        {
            if (user.Id == myId)
            {
                return FriendshipStatus.Myself;
            }

            else if (user.Friends.Any(f => f.FriendUserId == myId))
            {
                return FriendshipStatus.Friend;
            }

            else if (user.FriendRequests.Any(fr => fr.UserSenderId == myId))
            {
                return FriendshipStatus.Pending;
            }

            else if (user.SentFriendRequests.Any(sfr => sfr.UserReceiverId == myId))
            {
                return FriendshipStatus.Requested;
            }

            return FriendshipStatus.Stranger;
        }
    }
}
