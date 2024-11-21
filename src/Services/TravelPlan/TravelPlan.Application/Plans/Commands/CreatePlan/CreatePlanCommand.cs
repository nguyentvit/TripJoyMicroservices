namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public record CreatePlanCommand(PlanCreateDto Plan, Guid UserId) : ICommand<CreatePlanResult>;
    public record CreatePlanResult(Guid Id);
    public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public CreatePlanCommandValidator()
        {
            RuleFor(x => x.Plan)
                .NotNull()
                .WithMessage("Plan cannot be null");

            RuleFor(x => x.Plan.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MinimumLength(3)
                .WithMessage("Title should be at least 3 characters.");

            RuleFor(x => x.Plan.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required.")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Start date must be in the future.")
                .LessThan(x => x.Plan.EndDate)
                .WithMessage("Start date must be earlier than End date.");

            RuleFor(x => x.Plan.EndDate)
                .NotEmpty()
                .WithMessage("End date is required.")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("End date must be in the future.")
                .GreaterThanOrEqualTo(x => x.Plan.StartDate)
                .WithMessage("End date must be greater than or equal to Start date.");

            RuleFor(x => x.Plan.Avatar)
                .Must(AvatarIsValid)
                .WithMessage("If Avatar is provided, Avatar must be specified");

            RuleFor(x => x.Plan.EstimatedBudget)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Estimated budget must be a positive number.");

            RuleFor(x => x.Plan.Method)
                .Must(CreationMethodIsValid)
                .WithMessage("Method must be a valid value (Manual, AI).");

            RuleFor(x => x.Plan.Vehicle)
                .Must(VehicleIsValid)
                .WithMessage("Vehicle must be a valid value (Car, Plane, Train, Walk, Bicycle, Motorbike)");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Unauthorized");

            RuleFor(x => x.Plan.ProvinceEndId)
                .NotNull()
                .WithMessage("ProvinceEndId can not be null");

            RuleFor(x => x.Plan.ProvinceStartId)
                .NotNull()
                .WithMessage("ProvinceStartId can not be null");

        }

        private bool CreationMethodIsValid(CreationMethod creationMethod)
        {
            return Enum.IsDefined(typeof(CreationMethod), creationMethod);
        }
        private bool VehicleIsValid(PlanVehicle vehicle)
        {
            return Enum.IsDefined(typeof(PlanVehicle), vehicle);
        }

        private bool AvatarIsValid(string? avatar)
        {
            if (avatar != null)
            {
                return !string.IsNullOrWhiteSpace(avatar);
            }

            return true;
        }
    }
}
