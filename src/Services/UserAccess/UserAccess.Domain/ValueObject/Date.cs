namespace UserAccess.Domain.ValueObject
{
    public record Date
    {
        public DateTime Value { get; }
        [JsonConstructor]
        private Date(DateTime value) => Value = value;
        public static Date Of(string value)
        {
            if (DateTime.TryParse(value, out var date))
            {
                return new Date(date);
            }

            throw new DomainException("Invalid date format");
        }
    }
}
