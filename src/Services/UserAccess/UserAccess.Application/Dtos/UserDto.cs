namespace UserAccess.Application.Dtos
{
    public record UserDto(
        Guid Id,
        string UserName,
        string Email,
        string PhoneNumber,
        string? DateOfBirth,
        ImageDto? Avatar,
        AddressDto? Address,
        UserGender? Gender,
        List<Guid> FriendIds,
        List<Guid> FriendRequestIds,
        List<Guid> SentFriendRequestIds
        );
}
