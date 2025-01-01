
namespace TravelPlan.Application.Plans.Queries.GetPlanByPlanId
{
    public class GetPlanByPlanIdHandler
        (IApplicationDbContext dbContext, ILocationGrpcService grpcService) : IQueryHandler<GetPlanByPlanIdQuery, GetPlanByPlanIdResult>
    {
        public async Task<GetPlanByPlanIdResult> Handle(GetPlanByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);
            var planId = PlanId.Of(query.PlanId);

            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            plan.AccessPlan(userId);

            var planResult = await plan.ToPlanResponseDto(dbContext, grpcService);

            return new GetPlanByPlanIdResult(planResult);
        }
    }
}
