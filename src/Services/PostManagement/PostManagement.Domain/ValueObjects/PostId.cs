namespace PostManagement.Domain.ValueObjects
{
    public record PostId
    {
        public Guid Value { get; }
        private PostId(Guid value) => Value = value;
        public static PostId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }

            return new PostId(value);
        }
    }
}
