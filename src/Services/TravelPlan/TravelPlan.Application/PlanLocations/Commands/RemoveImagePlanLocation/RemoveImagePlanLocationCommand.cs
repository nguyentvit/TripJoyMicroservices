namespace TravelPlan.Application.PlanLocations.Commands.RemoveImagePlanLocation
{
    public record RemoveImagePlanLocationCommand(Guid UserId, Guid PlanLocationId, string ImageUrl) : ICommand<RemoveImagePlanLocationResult>;
    public record RemoveImagePlanLocationResult(bool IsSuccess);
    public class RemoveImagePlanLocationCommandValidator : AbstractValidator<RemoveImagePlanLocationCommand>
    {
        public RemoveImagePlanLocationCommandValidator()
        {

        }
    }
}
