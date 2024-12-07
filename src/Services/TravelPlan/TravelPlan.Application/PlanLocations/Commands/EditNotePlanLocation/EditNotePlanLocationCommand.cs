namespace TravelPlan.Application.PlanLocations.Commands.EditNotePlanLocation
{
    public record EditNotePlanLocationCommand(Guid UserId, Guid PlanLocationId, string Note) : ICommand<EditNotePlanLocationResult>;
    public record EditNotePlanLocationResult(bool IsSuccess);
    public class EditNotePlanLocationCommandValidator : AbstractValidator<EditNotePlanLocationCommand>
    {
        public EditNotePlanLocationCommandValidator()
        {

        }
    }
}
