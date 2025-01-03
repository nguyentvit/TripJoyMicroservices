﻿using BuildingBlocks.Dtos;
using BuildingBlocks.Pagination;

namespace BuildingBlocks.Interfaces
{
    public interface IUserAccessService
    {
        Task<List<UserInfoExternalServiceDto>> GetUsersInfoAsync(List<Guid> UserIds, CancellationToken cancellationToken = default);
        Task<PaginationResult<UserInfoExternalServiceDto>> GetAllUsersAsync(PaginationRequest PaginationRequest, KeySearchUser keySearch, CancellationToken cancellationToken = default);
    }
}
