namespace TravelPlan.Domain.ValueObjects
{
    public record ProvinceName
    {
        public string Value { get; }
        private ProvinceName(string value) => Value = value;
        public static ProvinceName Of(string value)
        {
            return new ProvinceName(value);
        }
    }
}
