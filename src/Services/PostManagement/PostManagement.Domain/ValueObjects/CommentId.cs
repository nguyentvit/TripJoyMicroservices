﻿namespace PostManagement.Domain.ValueObjects
{
    public record CommentId
    {
        public Guid Value { get; }
        private CommentId(Guid value) => Value = value;
        public static CommentId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PlanId cannot be empty.");
            }

            return new CommentId(value);
        }
    }
}