namespace Chat.Domain.ValueObjects
{
    public record ChatRoomName
    {
        private const int MinLength = 3;
        private const int MaxLength = 50;
        public string Value { get; }
        private ChatRoomName(string value) => Value = value;
        public static ChatRoomName Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, MinLength);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);

            return new ChatRoomName(value);
        }
    }
}
