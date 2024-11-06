namespace UserAccess.Application.Data
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken = default);
        Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken = default);
        DbSet<User> Users { get; }
        Task<User> GetUserById(UserId UserId, CancellationToken cancellationToken = default);

    }
}
