﻿namespace Chat.Domain.ValueObjects
{
    public record PlanId
    {
        public Guid Value { get; }
        private PlanId(Guid value) => Value = value;
        public static PlanId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new PlanId(value);
        }
    }
}
