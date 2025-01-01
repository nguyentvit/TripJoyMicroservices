namespace TravelPlan.Application.PlanLocations.Commands.RemovePlanLocation
{
    public record RemovePlanLocationCommand(Guid UserId, Guid PlanLocationId) : ICommand<RemovePlanLocationResult>;
    public record RemovePlanLocationResult(bool IsSuccess);
    public class RemovePlanLocationCommandValidator : AbstractValidator<RemovePlanLocationCommand>
    {
        public RemovePlanLocationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.PlanLocationId).NotEmpty().WithMessage("PlanLocationId is required.");
        }
    }
}
