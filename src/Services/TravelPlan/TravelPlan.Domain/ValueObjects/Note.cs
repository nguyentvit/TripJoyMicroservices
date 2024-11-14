namespace TravelPlan.Domain.ValueObjects
{
    public record Note
    {
        public string Value { get; }
        private Note(string value) => Value = value;
        public static Note Of(string value)
        {
            return new Note(value);
        }
    }
}
