namespace UserAccess.Application.Data
{
    public interface IUserRepository
    {
        DbSet<User> Users { get; }
        Task<User> GetUserById(UserId UserId, CancellationToken cancellationToken = default);

    }
}
