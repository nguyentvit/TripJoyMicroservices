namespace PostManagement.Domain.ValueObjects
{
    public record Order
    {
        public int Value { get; }
        private Order(int value) => Value = value;
        public static Order Of(int value)
        {
            if (value <= 0)
                throw new DomainException("PlanLocationOrder value must be greater than 0.");

            return new Order(value);
        }
    }
}
