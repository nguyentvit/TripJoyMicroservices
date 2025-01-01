namespace PostManagement.Domain.ValueObjects
{
    public record CommentReactionId
    {
        public Guid Value { get; }
        private CommentReactionId(Guid value) => Value = value;
        public static CommentReactionId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }

            return new CommentReactionId(value);
        }
    }
}
