namespace NotificationUser.SignalR.Plans.Commands.CreatePlan
{
    public record CreatePlanCommand(Guid PlanId, Guid UserId) : ICommand<CreatePlanResult>;
    public record CreatePlanResult(bool IsSuccess);
    public class CreatePlanHandler
        (IPlanRepository repository) : ICommandHandler<CreatePlanCommand, CreatePlanResult>
    {
        public async Task<CreatePlanResult> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = command.PlanId;
            var userId = command.UserId;

            var plan = new Plan(planId);

            await repository.CreatePlan(plan, cancellationToken);
            await repository.AddMember(planId, userId, cancellationToken);

            return new CreatePlanResult(true);
        }
    }
}
