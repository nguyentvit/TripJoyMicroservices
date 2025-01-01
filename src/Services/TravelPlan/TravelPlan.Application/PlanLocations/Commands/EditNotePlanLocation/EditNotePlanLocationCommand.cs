namespace TravelPlan.Application.PlanLocations.Commands.EditNotePlanLocation
{
    public record EditNotePlanLocationCommand(Guid UserId, Guid PlanLocationId, string Note) : ICommand<EditNotePlanLocationResult>;
    public record EditNotePlanLocationResult(bool IsSuccess);
    public class EditNotePlanLocationCommandValidator : AbstractValidator<EditNotePlanLocationCommand>
    {
        public EditNotePlanLocationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.PlanLocationId).NotEmpty().WithMessage("PlanLocationId is required.");
        }
    }
}
