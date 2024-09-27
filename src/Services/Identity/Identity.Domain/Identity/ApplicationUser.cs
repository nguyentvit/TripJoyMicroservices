namespace Identity.Domain.Identity
{
    public class ApplicationUser : IdentityUser, AggregateRoot
    {
        public string Name { get; set; } = default!;
    }
}
