namespace TravelPlan.Application.PlanLocations.Commands.RemoveImagePlanLocation
{
    public record RemoveImagePlanLocationCommand(Guid UserId, Guid PlanLocationId, string ImageUrl) : ICommand<RemoveImagePlanLocationResult>;
    public record RemoveImagePlanLocationResult(bool IsSuccess);
    public class RemoveImagePlanLocationCommandValidator : AbstractValidator<RemoveImagePlanLocationCommand>
    {
        public RemoveImagePlanLocationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.PlanLocationId).NotEmpty().WithMessage("PlanLocationId is required.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required.");
        }
    }
}
