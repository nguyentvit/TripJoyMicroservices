using Identity.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Domain.Common.Models
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<ApplicationUser> Users { get; }
    }
}
