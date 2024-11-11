namespace LocationAttraction.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Location> Locations { get; }
        DbSet<LocationCategory> LocationCategories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
