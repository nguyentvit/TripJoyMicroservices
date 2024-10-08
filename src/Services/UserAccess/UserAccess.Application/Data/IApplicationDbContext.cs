﻿using Microsoft.EntityFrameworkCore;

namespace UserAccess.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}