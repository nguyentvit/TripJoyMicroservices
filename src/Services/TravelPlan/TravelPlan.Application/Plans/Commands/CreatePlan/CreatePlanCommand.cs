namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public record CreatePlanCommand(PlanCreateDto Plan) : ICommand<CreatePlanResult>;
    public record CreatePlanResult(Guid Id);
    public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public CreatePlanCommandValidator()
        {

        }
    }
}
