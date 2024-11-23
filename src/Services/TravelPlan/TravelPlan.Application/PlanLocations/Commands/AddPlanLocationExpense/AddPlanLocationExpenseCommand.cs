namespace TravelPlan.Application.PlanLocations.Commands.AddPlanLocationExpense
{
    public record AddPlanLocationExpenseCommand(AddPlanLocationExpenseDto PlanLocationExpense, Guid UserId, Guid PlanLocationId) : ICommand<AddPlanLocationExpenseResult>;
    public record AddPlanLocationExpenseResult(bool IsSuccess);
    public class AddPlanLocationExpenseCommandValidator : AbstractValidator<AddPlanLocationExpenseCommand>
    {
        public AddPlanLocationExpenseCommandValidator()
        {
            RuleFor(x => x.PlanLocationId)
                .NotEmpty()
                .WithMessage("PlanId is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(x => x.PlanLocationExpense.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.PlanLocationExpense.PayerId)
                .NotEqual(Guid.Empty)
                .WithMessage("PayerId cannot be empty.");

            RuleFor(x => x.PlanLocationExpense.UserSpenderIds)
                .NotEmpty()
                .WithMessage("At least one spender must be specified")
                .Must(ids => ids.Select(i => i.UserId).Distinct().Count() == ids.Count)
                .WithMessage("Duplicate UserIds are not allowed in UserSpenderIds.");
        }
    }
}
