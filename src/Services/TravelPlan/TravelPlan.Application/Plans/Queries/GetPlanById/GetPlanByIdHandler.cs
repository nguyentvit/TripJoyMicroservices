namespace TravelPlan.Application.Plans.Queries.GetPlanById
{
    public class GetPlanByIdHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetPlanByIdQuery, GetPlanByIdResult>
    {
        public Task<GetPlanByIdResult> Handle(GetPlanByIdQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
