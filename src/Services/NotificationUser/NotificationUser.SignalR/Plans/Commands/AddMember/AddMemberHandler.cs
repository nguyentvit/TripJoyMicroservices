
namespace NotificationUser.SignalR.Plans.Commands.AddMember
{
    public record AddMemberCommand(Guid PlanId, Guid UserId) : ICommand<AddMemberResult>;
    public record AddMemberResult(bool IsSuccess);
    public class AddMemberHandler
        (IPlanRepository repository) : ICommandHandler<AddMemberCommand, AddMemberResult>
    {
        public async Task<AddMemberResult> Handle(AddMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = command.PlanId;
            var userId = command.UserId;

            await repository.AddMember(planId, userId, cancellationToken);

            return new AddMemberResult(true);
        }
    }
}
