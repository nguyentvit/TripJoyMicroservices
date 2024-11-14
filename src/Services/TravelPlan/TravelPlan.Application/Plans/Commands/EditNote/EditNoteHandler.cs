namespace TravelPlan.Application.Plans.Commands.EditNote
{
    public class EditNoteHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<EditNoteCommand, EditNoteResult>
    {
        public async Task<EditNoteResult> Handle(EditNoteCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(command.UserId);
            var note = Note.Of(command.Note);

            plan.EditNote(userId, note);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new EditNoteResult(true);
        }
    }
}
