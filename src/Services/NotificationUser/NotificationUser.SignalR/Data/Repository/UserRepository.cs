namespace NotificationUser.SignalR.Data.Repository
{
    public class UserRepository
        (IApplicationDbContext dbContext) : IUserRepository
    {
        public async Task<UserResponseDto> CreateUser(User user, CancellationToken cancellationToken = default)
        {
            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UserResponseDto(user.Id, user.UserFriends.Select(u => u.FriendId).ToList(), new List<string>());
        }
        public async Task<UserResponseDto> GetUser(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await dbContext.Users.Where(u => u.Id == userId).Select(u => new UserResponseDto(u.Id, u.UserFriends.Select(f => f.FriendId).ToList(), new List<string>())).FirstOrDefaultAsync();

            if (user == null)
                throw new UserNotFoundException(userId);

            return user;
        }
        public async Task<bool> AddFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default)
        {
            var userFirst = await GetUser(userIdFirst);
            var userSecond = await GetUser(userIdSecond);
            var userFriendFirst = new UserFriend(userIdSecond, userFirst.Id);
            var userFriendSecond = new UserFriend(userIdFirst, userSecond.Id);

            dbContext.UserFriends.Add(userFriendFirst);
            dbContext.UserFriends.Add(userFriendSecond);

            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> RemoveFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default)
        {
            var userFirst = await GetUser(userIdFirst);
            var userSecond = await GetUser(userIdSecond);

            var userFriendFirst = new UserFriend(userIdSecond, userFirst.Id);
            var userFriendSecond = new UserFriend(userIdFirst, userSecond.Id);

            dbContext.UserFriends.Remove(userFriendFirst);
            dbContext.UserFriends.Remove(userFriendSecond);

            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> AddConnectionId(Guid userId, string connectionId, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<Guid> RemoveConnectionId(string connectionId, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return Guid.Empty;
        }

        public async Task<List<Guid>> GetUserIds(CancellationToken cancellationToken = default)
        {
            var userIds = await dbContext.Users.Select(u => u.Id).ToListAsync();
            return userIds;
        }
    }
}
