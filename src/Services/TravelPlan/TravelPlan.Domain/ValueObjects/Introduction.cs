namespace TravelPlan.Domain.ValueObjects
{
    public record Introduction
    {
        public string Value { get; }
        private Introduction(string value) => Value = value;
        public static Introduction Of(string value)
        {
            return new Introduction(value);
        }
    }
}
