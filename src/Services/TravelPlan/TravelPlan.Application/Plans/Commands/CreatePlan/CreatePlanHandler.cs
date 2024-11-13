namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public class CreatePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<CreatePlanCommand, CreatePlanResult>
    {
        public Task<CreatePlanResult> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
