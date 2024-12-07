namespace NotificationUser.SignalR.Data.Repository
{
    public class PlanRepository
        (IApplicationDbContext dbContext) : IPlanRepository
    {
        public async Task<bool> AddMember(Guid planId, Guid userId, CancellationToken cancellationToken = default)
        {
            var plan = await GetPlan(planId);
            var planMember = new PlanMember(userId, plan.PlanId);

            dbContext.PlanMembers.Add(planMember);

            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<PlanResponseDto> CreatePlan(Plan plan, CancellationToken cancellationToken = default)
        {
            dbContext.Plans.Add(plan);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new PlanResponseDto(plan.Id, new List<Guid>());
        }

        public async Task<PlanResponseDto> GetPlan(Guid planId, CancellationToken cancellationToken = default)
        {
            var plan = await dbContext.Plans.Where(p => p.Id == planId).Select(p => new PlanResponseDto(p.Id, p.PlanMembers.Select(m => m.UserId).ToList())).FirstOrDefaultAsync(cancellationToken);

            if (plan == null)
                throw new PlanNotFoundException(planId);

            return plan;
        }

        public async Task<List<PlanResponseDto>> GetPlansByUserId(Guid userId, CancellationToken cancellation = default)
        {
            var plan = await dbContext.Plans.Where(p => p.PlanMembers.Any(m => m.UserId == userId)).Select(p => new PlanResponseDto(p.Id, p.PlanMembers.Select(m => m.UserId).ToList())).ToListAsync(cancellation);

            return plan;
        }

        public async Task<bool> RemoveMember(Guid planId, Guid userId, CancellationToken cancellationToken = default)
        {
            var plan = await GetPlan(planId);

            var planMember = new PlanMember(userId, plan.PlanId);

            dbContext.PlanMembers.Remove(planMember);

            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
