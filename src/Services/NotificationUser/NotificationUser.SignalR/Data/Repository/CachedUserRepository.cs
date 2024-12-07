namespace NotificationUser.SignalR.Data.Repository
{
    public class CachedUserRepository
        (IUserRepository repository, IDistributedCache cache) : IUserRepository
    {
        public async Task<UserResponseDto> CreateUser(User user, CancellationToken cancellationToken = default)
        {
            await repository.CreateUser(user, cancellationToken);

            await cache.SetStringAsync(user.Id.ToString(), JsonSerializer.Serialize(user), cancellationToken);

            return new UserResponseDto(user.Id, user.UserFriends.Select(u => u.FriendId).ToList(), new List<string>());
        }

        public async Task<UserResponseDto> GetUser(Guid userId, CancellationToken cancellationToken = default)
        {
            var cachedUser = await cache.GetStringAsync(userId.ToString(), cancellationToken);
            if (!string.IsNullOrEmpty(cachedUser))
                return JsonSerializer.Deserialize<UserResponseDto>(cachedUser)!;

            var user = await repository.GetUser(userId, cancellationToken);
            await cache.SetStringAsync(userId.ToString(), JsonSerializer.Serialize(user), cancellationToken);
            return user;
        }
        public async Task<bool> AddFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default)
        {
            await repository.AddFriend(userIdFirst, userIdSecond, cancellationToken);
            var userFirst = await repository.GetUser(userIdFirst, cancellationToken);
            var userSecond = await repository.GetUser(userIdSecond, cancellationToken);

            await cache.SetStringAsync(userIdFirst.ToString(), JsonSerializer.Serialize(userFirst), cancellationToken);
            await cache.SetStringAsync(userIdSecond.ToString(), JsonSerializer.Serialize(userSecond), cancellationToken);

            return true;
        }

        public async Task<bool> RemoveFriend(Guid userIdFirst, Guid userIdSecond, CancellationToken cancellationToken = default)
        {
            await repository.RemoveFriend(userIdFirst, userIdSecond, cancellationToken);

            var userFirst = await repository.GetUser(userIdFirst, cancellationToken);
            var userSecond = await repository.GetUser(userIdSecond, cancellationToken);

            await cache.SetStringAsync(userIdFirst.ToString(), JsonSerializer.Serialize(userFirst), cancellationToken);
            await cache.SetStringAsync(userIdSecond.ToString(), JsonSerializer.Serialize(userSecond), cancellationToken);

            return true;
        }

        public async Task<bool> AddConnectionId(Guid userId, string connectionId, CancellationToken cancellationToken = default)
        {
            await repository.AddConnectionId(userId, connectionId, cancellationToken);

            var user = await GetUser(userId, cancellationToken);
            user.ConnectionIds.Add(connectionId);

            await cache.SetStringAsync(userId.ToString(), JsonSerializer.Serialize(user), cancellationToken);
            return true;
        }

        public async Task<Guid> RemoveConnectionId(string connectionId, CancellationToken cancellationToken = default)
        {
            var userIds = await repository.GetUserIds(cancellationToken);
            foreach (var userId in userIds)
            {
                var cachedUser = await cache.GetStringAsync(userId.ToString(), cancellationToken);
                if (!string.IsNullOrEmpty(cachedUser))
                {
                    var user = JsonSerializer.Deserialize<UserResponseDto>(cachedUser)!;
                    if (user.ConnectionIds.Contains(connectionId))
                    {
                        user.ConnectionIds.Remove(connectionId);
                        await cache.SetStringAsync(userId.ToString(), JsonSerializer.Serialize(user), cancellationToken);
                        return userId;
                    }
                }
            }
            return Guid.Empty;
        }

        public async Task<List<Guid>> GetUserIds(CancellationToken cancellationToken = default)
        {
            return await repository.GetUserIds(cancellationToken);
        }
    }
}
