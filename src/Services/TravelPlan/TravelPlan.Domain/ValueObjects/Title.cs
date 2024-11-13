namespace TravelPlan.Domain.ValueObjects
{
    public record Title
    {
        public string Value { get; }
        private Title(string value) => Value = value;
        public static Title Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException("Title cannot be null or empty.");
            }
            value = value.Trim();
            if (value.Length < 3)
            {
                throw new DomainException("Title must be at least 3 characters long.");
            }
            if (value.Length > 100)
            {
                throw new DomainException("Title must not exceed 100 characters.");
            }
            return new Title(value);
        }
    }
}
