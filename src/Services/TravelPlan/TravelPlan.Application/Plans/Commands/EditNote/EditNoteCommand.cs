namespace TravelPlan.Application.Plans.Commands.EditNote
{
    public record EditNoteCommand(Guid UserId, Guid PlanId, string Note) : ICommand<EditNoteResult>;
    public record EditNoteResult(bool IsSuccess);
    public class EditNoteCommandValidator : AbstractValidator<EditNoteCommand>
    {
        public EditNoteCommandValidator()
        {
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
