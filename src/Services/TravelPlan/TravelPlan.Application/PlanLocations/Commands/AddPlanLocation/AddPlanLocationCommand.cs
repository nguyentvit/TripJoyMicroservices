namespace TravelPlan.Application.PlanLocations.Commands.AddPlanLocation
{
    public record AddPlanLocationCommand(Guid PlanId, Guid UserId, PlanLocationAddDto PlanLocation) : ICommand<AddPlanLocationResult>;
    public record AddPlanLocationResult(Guid PlanLocationId);
    public class AddPlanLocationCommandValidator : AbstractValidator<AddPlanLocationCommand>
    {
        public AddPlanLocationCommandValidator()
        {
            RuleFor(x => x.PlanId)
                .NotEmpty()
                .WithMessage("PlanId is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(x => x.PlanLocation.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.PlanLocation.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Longitude must be between -180 and 180.");

            RuleFor(x => x.PlanLocation.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.PlanLocation.Address)
                .NotEmpty()
                .WithMessage("Address is required.");
        }
    }
}
