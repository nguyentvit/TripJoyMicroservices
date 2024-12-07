
namespace TravelPlan.Application.PlanLocations.Commands.EditNotePlanLocation
{
    public class EditNotePlanLocationHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<EditNotePlanLocationCommand, EditNotePlanLocationResult>
    {
        public async Task<EditNotePlanLocationResult> Handle(EditNotePlanLocationCommand command, CancellationToken cancellationToken)
        {
            var planLocationId = PlanLocationId.Of(command.PlanLocationId);
            var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
            if (planLocation == null)
                throw new PlanLocationNotFoundException(planLocationId.Value);

            var plan = await dbContext.Plans.FindAsync([planLocation.PlanId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planLocation.PlanId.Value);

            var userId = UserId.Of(command.UserId);

            plan.EditPlanLocation(userId);

            var note = Note.Of(command.Note);
            planLocation.EditNotePlanLocation(note);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new EditNotePlanLocationResult(true);
            
        }
    }
}
