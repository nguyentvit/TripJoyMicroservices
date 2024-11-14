namespace TravelPlan.Application.Plans.Commands.UpdatePlan
{
    public record UpdatePlanCommand(PlanUpdateDto Plan, Guid UserId, Guid PlanId) : ICommand<UpdatePlanResult>;
    public record UpdatePlanResult(bool IsSuccess);
    public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
    {
        public UpdatePlanCommandValidator()
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

            RuleFor(x => x.Plan.Visibility)
                .Must(VisibilityIsValid)
                .WithMessage("Visibility must be a valid value (Private, Friend, Public).");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Unauthorized");

            RuleFor(x => x.PlanId)
                .NotNull()
                .NotEmpty()
                .WithMessage("PlanId cannot be null");
        }
        private bool VisibilityIsValid(Visibility visibility)
        {
            return Enum.IsDefined(typeof(Visibility), visibility);
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
