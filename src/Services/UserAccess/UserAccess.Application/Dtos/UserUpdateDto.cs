namespace UserAccess.Application.Dtos
{
    public record UserUpdateDto(
        Guid Id,
        string UserName,
        string PhoneNumber,
        DateTime DateOfBirth,
        ImageDto Avatar,
        AddressDto Address,
        UserGender Gender
        );
}
