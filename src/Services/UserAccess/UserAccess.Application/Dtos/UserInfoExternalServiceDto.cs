﻿namespace UserAccess.Application.Dtos
{
    public record UserInfoExternalServiceDto(Guid UserId, string UserName, string? Avatar);
}