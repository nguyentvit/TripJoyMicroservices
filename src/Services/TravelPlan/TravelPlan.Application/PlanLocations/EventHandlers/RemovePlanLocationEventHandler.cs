
namespace TravelPlan.Application.PlanLocations.EventHandlers
{
    public class RemovePlanLocationEventHandler
        (IApplicationDbContext dbContext,
        IS3Service s3Service) : IDomainEventHandler<RemovePlanLocationEvent>
    {
        public async Task Handle(RemovePlanLocationEvent notification, CancellationToken cancellationToken)
        {
            var plan = notification.Plan;
            var planLocationIds = plan.PlanLocationIds;

            var planLocationRemoved = notification.PlanLocation;

            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                if (planLocation.Order.Value > planLocationRemoved.Order.Value)
                {
                    var order = PlanLocationOrder.Of(planLocation.Order.Value - 1);
                    planLocation.ChangeOrder(order);
                }
            }

            foreach (var image in planLocationRemoved.Images)
            {
                await s3Service.DeleteFileAsync(image.Image.Url);
            }
        }
    }
}
