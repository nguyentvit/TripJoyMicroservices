
namespace TravelPlan.Application.PlanLocations.Queries.GetPlanLocationById
{
    public class GetPlanLocationByIdHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService grpcService,
        IUserAccessService userService) : IQueryHandler<GetPlanLocationByIdQuery, GetPlanLocationByIdResult>
    {
        public async Task<GetPlanLocationByIdResult> Handle(GetPlanLocationByIdQuery query, CancellationToken cancellationToken)
        {
            var planLocationId = PlanLocationId.Of(query.PlanLocationId);
            var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId], cancellationToken);
            if (planLocation == null)
                throw new PlanLocationNotFoundException(planLocationId.Value);

            var planId = planLocation.PlanId;
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);
            plan.AccessPlan(userId);

            var planLocationResult = await planLocation.ToPlanLocationResponseDto(grpcService, userService);

            return new GetPlanLocationByIdResult(planLocationResult);
        }
    }
}
