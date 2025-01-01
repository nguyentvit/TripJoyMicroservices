namespace PostManagement.Domain.ValueObjects
{
    public record LikeCount
    {
        public int Value { get; private set; } = default!;
        private LikeCount(int value) => Value = value;
        public static LikeCount Of(int value)
        {
            return new LikeCount(value);
        }
    }
}
