namespace Identity.Application.Dtos
{
    public class AccountCreatedDto
    {
        public Guid AccountId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
