namespace TravelPlan.Application.PlanLocations.Commands.AddImagePlanLocation
{
    public record AddImagePlanLocationCommand(Guid UserId, Guid PlanLocationId, IFormFile Image) : ICommand<AddImagePlanLocationResult>;
    public record AddImagePlanLocationResult(bool IsSuccess);
    public class AddImagePlanLocationCommandHandler : AbstractValidator<AddImagePlanLocationCommand>
    {
        public AddImagePlanLocationCommandHandler()
        {

        }
    }
}
