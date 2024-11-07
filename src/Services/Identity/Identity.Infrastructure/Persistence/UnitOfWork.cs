namespace Identity.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext _dbContext;
        public UnitOfWork(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<ApplicationUser> Users => _dbContext.ApplicationUsers;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
