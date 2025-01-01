namespace PostManagement.Domain.ValueObjects
{
    public record PostImageId
    {
        public Guid Value { get; }
        private PostImageId(Guid value) => Value = value;
        public static PostImageId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }
            return new PostImageId(value);
        }
    }
}
