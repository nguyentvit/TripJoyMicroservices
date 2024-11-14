﻿namespace TravelPlan.Application.Plans.Commands.AddMember
{
    public record AddMemberCommand(Guid PlanId, Guid UserId, Guid TargetUserId) : ICommand<AddMemberResult>;
    public record AddMemberResult(bool IsSuccess);
    public class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
    {
        public AddMemberCommandValidator()
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
