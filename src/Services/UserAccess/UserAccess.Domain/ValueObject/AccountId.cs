namespace UserAccess.Domain.ValueObject
{
    public record AccountId
    {
        public string Value { get; }
        [JsonConstructor]
        private AccountId(string value) => Value = value;
        public static AccountId Of(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == string.Empty)
            {
                throw new DomainException("AccountId cannot be empty.");
            }

            return new AccountId(value);
        }
    }
}
