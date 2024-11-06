namespace UserAccess.Application.Dtos
{
    public record UserUpdateDto(
        string AccountId,
        string UserName,
        string PhoneNumber,
        string? DateOfBirth,
        ImageDto? Avatar,
        AddressDto? Address,
        UserGender? Gender
        );
}
