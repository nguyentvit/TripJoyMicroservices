namespace PostManagement.Domain.ValueObjects
{
    public record PostReactionId
    {
        public Guid Value { get; }
        private PostReactionId(Guid value) => Value = value;
        public static PostReactionId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }

            return new PostReactionId(value);
        }
    }
}
