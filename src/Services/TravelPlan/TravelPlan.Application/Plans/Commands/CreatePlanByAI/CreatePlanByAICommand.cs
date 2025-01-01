namespace TravelPlan.Application.Plans.Commands.CreatePlanByAI
{
    public record CreatePlanByAICommand(CreatePlanByAIDto Plan, Guid UserId) : ICommand<CreatePlanByAIResult>;
    public record CreatePlanByAIResult(Guid PlanId);
}
