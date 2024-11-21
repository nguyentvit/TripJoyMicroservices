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
                planResponseLocationDto.Add(new PlanResponseLocationDto("123", 123, 123, 1));
            }

            var leadUserId = plan.PlanMembers.Where(pm => pm.Role == MemberRole.Lead).FirstOrDefault();
            if (leadUserId == null)
                throw new LeaderNotFoundException();

            var planResponseDto = new PlanResponseDto(
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
