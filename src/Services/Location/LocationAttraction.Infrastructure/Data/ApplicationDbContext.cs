using LocationAttraction.Application.Data;
using System.Reflection;

namespace LocationAttraction.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<LocationCategory> LocationCategories => Set<LocationCategory>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //builder.Entity<LocationCategory>().HasData(new LocationCategory
            //{
            //    Id = LocationCategoryId.Of(Guid.Parse("662b471a-1b58-48d7-a2ea-d271bec1eb16")),
            //    CreatedAt = DateTime.Now,
            //    CreatedBy = "sodro",
            //    Description = Description.Of("Thú vị"),
            //    LastModified = DateTime.Now,
            //    LastModifiedBy = "sodro",
            //    Name = Name.Of("hotel")
            //});
            builder.Entity<LocationCategory>().HasData(LocationCategory.Of(LocationCategoryId.Of(Guid.Parse("662b471a-1b58-48d7-a2ea-d271bec1eb16")), Name.Of("Hotel"), Description.Of("Thú vị")));

            base.OnModelCreating(builder);
        }
    }
}
