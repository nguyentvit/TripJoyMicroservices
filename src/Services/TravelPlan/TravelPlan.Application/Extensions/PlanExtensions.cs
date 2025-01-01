namespace TravelPlan.Application.Extensions
{
    public static class PlanExtensions
    {
        public static async Task<PlanResponseDto> ToPlanResponseDto(this Plan plan, IApplicationDbContext dbContext, ILocationGrpcService grpcService)
        {
            return await PlanResponseFromPlan(plan, dbContext, grpcService);
        }
        public static async Task<PlanExpenseDto> ToPlanExpenseDto(this Plan plan, UserId userId,PaginationRequest request , IApplicationDbContext dbContext, ILocationGrpcService locationGrpcService)
        {
            return await PlanExpenseDtoFromPlanAndUserId(plan, userId, dbContext, request, locationGrpcService);
        }
        public static async Task<GetPlansAvailableToJoinDto> ToGetPlansAvailableToJoinDto(this Plan plan, IApplicationDbContext dbContext, UserId userId)
        {
            return await GetPlansAvailableToJoinDtoFromPlan(plan, dbContext, userId);
        }
        public static async Task<GetPlanAvailableToJoinByPlanIdDtoPlan> ToGetPlanAvailableToJoinByPlanIdDtoPlan(this Plan plan, IApplicationDbContext dbContext, UserId userId)
        {
            return await GetPlanAvailableToJoinByPlanIdDtoPlanFromPlan(plan, dbContext, userId);
        }
        private static async Task<PlanResponseDto> PlanResponseFromPlan(Plan plan, IApplicationDbContext dbContext, ILocationGrpcService grpcService)
        {
            var planLocationIds = plan.PlanLocationIds;
            var planResponseLocationDto = new List<PlanResponseLocationDto>();
            var planImages = new List<PlanResponseImageDto>();
            foreach (var planLocationId in planLocationIds)
            {
                var planLocation = await dbContext.PlanLocations.FindAsync([planLocationId]);
                if (planLocation == null)
                    throw new PlanLocationNotFoundException(planLocationId.Value);

                var location = await grpcService.GetLocationByLocationId(planLocation.LocationId.Value.ToString());
                if (location == null)
                    throw new Exception("Location not found");
                planResponseLocationDto.Add(new PlanResponseLocationDto(planLocation.Id.Value, new PlanResponseLocationDtoCoordinates(planLocation.Coordinates.Latitude, planLocation.Coordinates.Longitude), planLocation.Order.Value, location.Name, location.Address, planLocation.EstimatedStartDate.Value));
                foreach (var image in planLocation.Images)
                {
                    planImages.Add(new PlanResponseImageDto(image.Image.Url));
                }
            }
            planResponseLocationDto = planResponseLocationDto.OrderBy(p => p.Order).ToList();
            var leadUserId = plan.PlanMembers.Where(pm => pm.Role == MemberRole.Lead).FirstOrDefault();
            if (leadUserId == null)
                throw new LeaderNotFoundException();


            var provinceStart = await dbContext.Provinces.FindAsync([plan.ProvinceStartId]);
            if (provinceStart == null)
                throw new ProvinceNotFoundException(plan.ProvinceStartId.Value);
            var provinceEnd = await dbContext.Provinces.FindAsync([plan.ProvinceEndId]);
            if (provinceEnd == null)
                throw new ProvinceNotFoundException(plan.ProvinceEndId.Value);
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
                Method: plan.Method,
                ProvinceStart: new PlanResponseProvinceDto(provinceStart.Id.Value, provinceStart.Name.Value),
                ProvinceEnd: new PlanResponseProvinceDto(provinceEnd.Id.Value, provinceEnd.Name.Value),
                Images: planImages,
                JoinStatus: plan.JoinStatus
                );

            return planResponseDto;
        }
        private static async Task<PlanExpenseDto> PlanExpenseDtoFromPlanAndUserId(Plan plan, UserId userId, IApplicationDbContext dbContext, PaginationRequest request, ILocationGrpcService locationGrpcService)
        {
            decimal expense = 0;
            decimal excess = 0;
            decimal totalExpense = 0;

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

                    totalExpense += planLocation.Amount.Value;
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

            return new PlanExpenseDto(totalExpense, expense, excess, totalCount, detailExpense);
        }
        private static async Task<GetPlansAvailableToJoinDto> GetPlansAvailableToJoinDtoFromPlan(Plan plan, IApplicationDbContext dbContext, UserId userId)
        {
            var provinceStart = await dbContext.Provinces.FindAsync([plan.ProvinceStartId]);
            if (provinceStart == null)
                throw new ProvinceNotFoundException(plan.ProvinceStartId.Value);

            var provinceEnd = await dbContext.Provinces.FindAsync([plan.ProvinceEndId]);
            if (provinceEnd == null)
                throw new ProvinceNotFoundException(plan.ProvinceEndId.Value);

            return new GetPlansAvailableToJoinDto(
                Id: plan.Id.Value,
                Title: plan.Title.Value,
                Avatar: plan.Avatar?.Url,
                StartDate: plan.StartDate.Value,
                EndDate: plan.EndDate.Value,
                EstimatedBudget: plan.EstimatedBudget.Value,
                ProvinceStart: new GetPlansAvailableToJoinDtoProvince(provinceStart.Id.Value, provinceStart.Name.Value),
                ProvinceEnd: new GetPlansAvailableToJoinDtoProvince(provinceEnd.Id.Value, provinceEnd.Name.Value),
                ApplyStatus: (plan.PlanJoinRequests.Any(j => j.UserId == userId)) ? true : false
                );
        }
        private static async Task<GetPlanAvailableToJoinByPlanIdDtoPlan> GetPlanAvailableToJoinByPlanIdDtoPlanFromPlan(Plan plan, IApplicationDbContext dbContext, UserId userId)
        {
            var provinceStart = await dbContext.Provinces.FindAsync([plan.ProvinceStartId]);
            if (provinceStart == null)
                throw new ProvinceNotFoundException(plan.ProvinceStartId.Value);

            var provinceEnd = await dbContext.Provinces.FindAsync([plan.ProvinceEndId]);
            if (provinceEnd == null)
                throw new ProvinceNotFoundException(plan.ProvinceEndId.Value);

            return new GetPlanAvailableToJoinByPlanIdDtoPlan(
                PlanId: plan.Id.Value,
                Title: plan.Title.Value,
                Avatar: plan.Avatar?.Url,
                StartDate: plan.StartDate.Value,
                EndDate: plan.EndDate.Value,
                EstimatedBudget: plan.EstimatedBudget.Value,
                ProvinceStart: new GetPlanAvailableToJoinByPlanIdDtoPlanProvince(provinceStart.Id.Value, provinceStart.Name.Value),
                ProvinceEnd: new GetPlanAvailableToJoinByPlanIdDtoPlanProvince(provinceEnd.Id.Value, provinceEnd.Name.Value),
                ApplyStatus: (plan.PlanJoinRequests.Any(j => j.UserId == userId)) ? true : false
                );
        }
    }
}
