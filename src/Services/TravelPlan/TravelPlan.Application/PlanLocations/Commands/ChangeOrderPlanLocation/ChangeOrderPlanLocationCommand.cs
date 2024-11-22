namespace TravelPlan.Application.PlanLocations.Commands.ChangeOrderPlanLocation
{
    public record ChangeOrderPlanLocationCommand(Guid UserId, Guid PlanId, Guid PlanLocationIdFirst, Guid PlanLocationIdSecond) : ICommand<ChangeOrderPlanLocationResult>;
    public record ChangeOrderPlanLocationResult(bool IsSuccess);
    public class ChangeOrderPlanLocationCommandValidator : AbstractValidator<ChangeOrderPlanLocationCommand>
    {
        public ChangeOrderPlanLocationCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(x => x.PlanId)
                .NotEmpty()
                .WithMessage("PlanId is required.");

            RuleFor(x => x.PlanLocationIdFirst)
                .NotEmpty()
                .WithMessage("PlanLocationIdFirst is required.");

            RuleFor(x => x.PlanLocationIdSecond)
                .NotEmpty()
                .WithMessage("PlanLocationIdSecond is required.");

            RuleFor(x => x)
                .Must(x => x.PlanLocationIdFirst != x.PlanLocationIdSecond)
                .WithMessage("PlanLocationIdFirst and PlanLocationIdSecond cannot be the same.");
        }
    }
}
