namespace UserAccess.Application.Dtos
{
    public record AddressDto(
        string District,
        string Ward,
        string Province,
        string Country);
}
