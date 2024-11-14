namespace TravelPlan.Application.Plans.Commands.ChangePermission
{
    public record ChangePermissionCommand(Guid PlanId, Guid UserId, Guid TargetUserId) 
        : ICommand<ChangePermissionResult>;
    public record ChangePermissionResult(bool IsSuccess);
    public class ChangePermissionCommandValidator : AbstractValidator<ChangePermissionCommand>
    {
        public ChangePermissionCommandValidator()
        {
            RuleFor(x => x.TargetUserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Target User ID is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("User ID is required.");

            RuleFor(x => x.PlanId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Plan ID is required.");
        }
    }
}
