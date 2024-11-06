using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace UserAccess.Application.Data
{
    public class CachedUserRepository
        (IUserRepository repository,
        IDistributedCache cache)
        : IUserRepository
    {
        public DbSet<User> Users => repository.Users;

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await repository.AddUserAsync(user, cancellationToken);

            await cache.SetStringAsync(user.Id.Value.ToString(), JsonSerializer.Serialize(user), cancellationToken);

            return user;
        }

        public async Task<User> GetUserById(UserId UserId, CancellationToken cancellationToken = default)
        {
            var cachedUser = await cache.GetStringAsync(UserId.Value.ToString(), cancellationToken);
            if (!string.IsNullOrEmpty(cachedUser))
                return JsonSerializer.Deserialize<User>(cachedUser)!;

            var user = await repository.GetUserById(UserId, cancellationToken);
            await cache.SetStringAsync(UserId.Value.ToString(), JsonSerializer.Serialize(user), cancellationToken);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await repository.UpdateUserAsync(user, cancellationToken);

            await cache.SetStringAsync(
                user.Id.Value.ToString(),
                JsonSerializer.Serialize(user),
                cancellationToken);

            return user;
        }
    }
}
