using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        public DbSet<OTPPw> OTPPws { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OTP>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder.Entity<OTPPw>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Customer",
            NormalizedName = "CUSTOMER"
        }
    );
        }
    }
}
