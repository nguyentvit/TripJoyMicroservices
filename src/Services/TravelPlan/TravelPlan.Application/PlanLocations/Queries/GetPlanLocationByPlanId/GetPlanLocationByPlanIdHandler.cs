namespace TravelPlan.Application.PlanLocations.Queries.GetPlanLocationByPlanId
{
    public class GetPlanLocationByPlanIdHandler
        (IApplicationDbContext dbContext,
        ILocationGrpcService grpcService)
        : IQueryHandler<GetPlanLocationByPlanIdQuery, GetPlanLocationByPlanIdResult>
    {
        public async Task<GetPlanLocationByPlanIdResult> Handle(GetPlanLocationByPlanIdQuery query, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(query.PlanId);
            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId.Value);

            var userId = UserId.Of(query.UserId);

            plan.AccessPlan(userId);
            
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = plan.PlanLocationIds.Count;

            var planLocations = await dbContext.PlanLocations
                .Where(p => p.PlanId == planId)
                .OrderBy(p => p.Order)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var planLocationsResult = new List<PlanLocationResponseDto>();

            foreach (var planLocation in planLocations)
            {
                var planLocationResult = await planLocation.ToPlanLocationResponseDto(grpcService);
                planLocationsResult.Add(planLocationResult);
            }

            var provinceStart = await dbContext.Provinces.FindAsync([plan.ProvinceStartId], cancellationToken);
            if (provinceStart == null)
                throw new ProvinceNotFoundException(plan.ProvinceStartId.Value);

            var provinceEnd = await dbContext.Provinces.FindAsync([plan.ProvinceEndId], cancellationToken);
            if (provinceEnd == null)
                throw new ProvinceNotFoundException(plan.ProvinceEndId.Value);

            var role = plan.PlanMembers.Where(pm => pm.MemberId == userId).FirstOrDefault();

            if (role == null)
                throw new Exception("UserNotFound");

            var planDetailResponseDto = new PlanDetailResponseDto(
                Title: plan.Title.Value,
                EstimatedStartDate: plan.StartDate.Value,
                EstimatedEndDate: plan.EndDate.Value,
                Method: plan.Method,
                Vehicle: plan.Vehicle,
                ProvinceStart: new PlanDetailProvinceResponseDto(provinceStart.Id.Value, provinceStart.Name.Value),
                ProvinceEnd: new PlanDetailProvinceResponseDto(provinceEnd.Id.Value, provinceEnd.Name.Value),
                Status: plan.Status,
                Avatar: (plan.Avatar != null) ? plan.Avatar.Url : null,
                Note: plan.Note.Value,
                EstimatedBudget: plan.EstimatedBudget.Value,
                Role: role.Role
                );

            return new GetPlanLocationByPlanIdResult(new PaginationResult<PlanLocationResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                planLocationsResult
                ), planDetailResponseDto);


        }
    }
}
