using System.Reflection;
using PostManagement.Application.Data;

namespace PostManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PlanPost> PlanPosts => Set<PlanPost>();
        public DbSet<Comment> Comments => Set<Comment>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
