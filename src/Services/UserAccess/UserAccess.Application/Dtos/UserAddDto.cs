namespace UserAccess.Application.Dtos
{
    public record UserAddDto(
        Guid Id,
        string UserName,
        string Email,
        string PhoneNumber
        );
}
