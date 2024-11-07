using UserAccess.Application.Data;
using UserAccess.Application.Exceptions;

namespace UserAccess.Infrastructure.Data.Repositories
{
    public class UserRepository
        (IApplicationDbContext dbContext) : IUserRepository
    {
        public DbSet<User> Users => dbContext.Users;

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<User> GetUserById(UserId UserId, CancellationToken cancellationToken = default)
        {
            var user = await dbContext.Users.FindAsync([UserId], cancellationToken);
            return user is null ? throw new UserNotFoundException(UserId.Value) : user;
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
