namespace UserAccess.Application.Dtos
{
    public record UserResponseDto(
        Guid Id,
        string UserName,
        string Email,
        string PhoneNumber,
        string? DateOfBirth,
        ImageDto? Avatar,
        AddressDto? Address,
        UserGender? Gender
        );
}
