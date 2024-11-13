namespace TravelPlan.Domain.Entities
{
    public class PlanLocationExpense : Entity<PlanLocationExpenseId>
    {
        public Title Title { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public Money Amount { get; private set; } = default!;
        private PlanLocationExpense() { }
        private PlanLocationExpense(PlanLocationExpenseId id, Title title, Note note, Money amount)
        {
            Title = title;
            Note = note;
            Amount = amount;
            Id = id;
        }
        public static PlanLocationExpense Of(Title title, Note note, Money amount)
        {
            ArgumentNullException.ThrowIfNull(title);
            ArgumentNullException.ThrowIfNull(note);
            ArgumentNullException.ThrowIfNull(amount);

            return new PlanLocationExpense(
                PlanLocationExpenseId.Of(Guid.NewGuid()),
                title,
                note,
                amount);
        }
    }
}
