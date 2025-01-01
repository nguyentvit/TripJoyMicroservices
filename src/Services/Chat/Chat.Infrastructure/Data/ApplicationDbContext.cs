using Chat.Application.Data;
using Chat.Domain.Models;
using System.Reflection;

namespace Chat.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();
        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
