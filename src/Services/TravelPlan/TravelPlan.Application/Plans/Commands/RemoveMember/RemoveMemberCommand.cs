namespace TravelPlan.Application.Plans.Commands.RemoveMember
{
    public record RemoveMemberCommand(Guid PlanId, Guid UserId, Guid TargetUserId) : ICommand<RemoveMemberResult>;
    public record RemoveMemberResult(bool IsSuccess);
    public class RemoveMemberCommandValidator : AbstractValidator<RemoveMemberCommand>
    {
        public RemoveMemberCommandValidator()
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
