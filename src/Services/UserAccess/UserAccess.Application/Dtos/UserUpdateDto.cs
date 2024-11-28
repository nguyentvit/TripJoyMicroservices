using Microsoft.AspNetCore.Http;

namespace UserAccess.Application.Dtos
{
    public record UserUpdateDto(
        Guid UserId,
        string UserName,
        string? PhoneNumber,
        string? DateOfBirth,
        IFormFile? Avatar,
        AddressDto? Address,
        UserGender? Gender
        );
}
