namespace TravelPlan.Application.Extensions
{
    public static class PlanExtensions
    {
        public static async Task<PlanResponseDto> ToPlanResponseDto(this Plan plan, IApplicationDbContext dbContext)
        {
            return await PlanResponseFromPlan(plan, dbContext);
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
    }
}
