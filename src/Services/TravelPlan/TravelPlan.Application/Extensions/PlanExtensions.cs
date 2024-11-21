namespace TravelPlan.Application.Extensions
{
    public static class PlanExtensions
    {
        public static PlanResponseDto ToPlanResponseDto(this Plan plan)
        {
            return PlanResponseFromPlan(plan);
        }
        private static PlanResponseDto PlanResponseFromPlan(Plan plan)
        {
            return new PlanResponseDto();
        }
    }
}
