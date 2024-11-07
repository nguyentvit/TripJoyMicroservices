namespace UserAccess.Application.Dtos
{
    public record UserUpdateDto(
        Guid UserId,
        string UserName,
        string PhoneNumber,
        string? DateOfBirth,
        ImageDto? Avatar,
        AddressDto? Address,
        UserGender? Gender
        );
}
