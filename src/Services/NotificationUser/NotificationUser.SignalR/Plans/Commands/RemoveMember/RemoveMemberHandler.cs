
namespace NotificationUser.SignalR.Plans.Commands.RemoveMember
{
    public record RemoveMemberCommand(Guid PlanId, Guid UserId) : ICommand<RemoveMemberResult>;
    public record RemoveMemberResult(bool IsSuccess);
    public class RemoveMemberHandler
        (IPlanRepository repository) : ICommandHandler<RemoveMemberCommand, RemoveMemberResult>
    {
        public async Task<RemoveMemberResult> Handle(RemoveMemberCommand command, CancellationToken cancellationToken)
        {
            var planId = command.PlanId;
            var userId = command.UserId;

            await repository.RemoveMember(planId, userId, cancellationToken);

            return new RemoveMemberResult(true);
        }
    }
}
