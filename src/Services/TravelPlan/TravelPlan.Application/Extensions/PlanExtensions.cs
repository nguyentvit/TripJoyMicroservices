namespace TravelPlan.Application.Extensions
{
    public static class PlanExtensions
    {
        public static async Task<PlanResponseDto> ToPlanResponseDto(this Plan plan, IApplicationDbContext dbContext)
        {
            return await PlanResponseFromPlan(plan, dbContext);
        }
        public static async Task<PlanExpenseDto> ToPlanExpenseDto(this Plan plan, UserId userId,PaginationRequest request , IApplicationDbContext dbContext, ILocationGrpcService locationGrpcService)
        {
            return await PlanExpenseDtoFromPlanAndUserId(plan, userId, dbContext, request, locationGrpcService);
        }
        private static async Task<PlanResponseDto> PlanResponseFromPlan(Plan plan, IApplicationDbContext dbContext)
        {
            var planLocationIds = plan.PlanLocationIds;
            var planResponseLocationDto = new List<PlanResponseLocationDto>();

            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId]);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);
                planResponseLocationDto.Add(new PlanResponseLocationDto(planLocation.Id.Value, planLocation.Coordinates.Latitude, planLocation.Coordinates.Longitude, planLocation.Order.Value));
            }
            planResponseLocationDto = planResponseLocationDto.OrderBy(p => p.Order).ToList();
            var leadUserId = plan.PlanMembers.Where(pm => pm.Role == MemberRole.Lead).FirstOrDefault();
            if (leadUserId == null)
                throw new LeaderNotFoundException();

            var planResponseDto = new PlanResponseDto(
                Id: plan.Id.Value,
                LeadUserId: leadUserId.MemberId.Value,
                Title: plan.Title.Value,
                Avatar: (plan.Avatar != null) ? plan.Avatar.Url : null,
                StartDate: plan.StartDate.Value,
                EndDate: plan.EndDate.Value,
                EstimatedBudget: plan.EstimatedBudget.Value,
                Locations: planResponseLocationDto,
                Vehicle: plan.Vehicle,
                Status: plan.Status,
                Method: plan.Method
                );

            return planResponseDto;
        }
        private static async Task<PlanExpenseDto> PlanExpenseDtoFromPlanAndUserId(Plan plan, UserId userId, IApplicationDbContext dbContext, PaginationRequest request, ILocationGrpcService locationGrpcService)
        {
            decimal expense = 0;
            decimal excess = 0;

            var planLocationIds = plan.PlanLocationIds;
            var planLocations = new List<PlanLocation>();

            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId]);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                decimal amount = 0;

                if (planLocation.Amount != null && planLocation.PlanLocationUserSpenders.Count > 0)
                {
                    amount = (planLocation.Amount.Value / planLocation.PlanLocationUserSpenders.Count);
                }

                if (planLocation.ExistUserIdInUserSpender(userId))
                {
                    planLocations.Add(planLocation);
                    expense += amount;
                    excess -= amount;
                }

                if (planLocation.PayerId == userId)
                    excess += (amount * (planLocation.PlanLocationUserSpenders.Count));
            }

            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;
            var totalCount = planLocations.Count;

            var sortedPlanLocations = planLocations
                .OrderBy(pl => pl.Order.Value)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            List<ExpenseResponseDto> detailExpense = new();

            foreach (var planLocation in sortedPlanLocations)
            {
                var location = await locationGrpcService.GetLocationByLocationId(planLocation.LocationId.Value.ToString());
                detailExpense.Add(new ExpenseResponseDto(
                    Order: planLocation.Order.Value,
                    Name: location.Name,
                    Address: location.Address,
                    Amount: (planLocation.Amount != null && planLocation.PlanLocationUserSpenders.Count > 0) ? (planLocation.Amount.Value / planLocation.PlanLocationUserSpenders.Count) : 0
                    ));
            }

            return new PlanExpenseDto(expense, excess, totalCount, detailExpense);
        }
    }
}
