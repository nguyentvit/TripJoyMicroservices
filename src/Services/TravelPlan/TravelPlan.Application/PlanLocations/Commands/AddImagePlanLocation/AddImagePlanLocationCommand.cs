namespace TravelPlan.Application.PlanLocations.Commands.AddImagePlanLocation
{
    public record AddImagePlanLocationCommand(Guid UserId, Guid PlanLocationId, IFormFile Image) : ICommand<AddImagePlanLocationResult>;
    public record AddImagePlanLocationResult(string Url, bool IsSuccess);
    public class AddImagePlanLocationCommandHandler : AbstractValidator<AddImagePlanLocationCommand>
    {
        public AddImagePlanLocationCommandHandler()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PlanLocationId).NotEmpty();
            RuleFor(x => x.Image).NotNull().WithMessage("Image file is required.");
        }
    }
}
