namespace NotificationUser.SignalR.Data.Repository
{
    public class CachedPlanRepository
        (IPlanRepository repository, IDistributedCache cache) : IPlanRepository
    {
        public async Task<bool> AddMember(Guid planId, Guid userId, CancellationToken cancellationToken = default)
        {
            await repository.AddMember(planId, userId, cancellationToken);
            var plan = await repository.GetPlan(planId, cancellationToken);

            await cache.SetStringAsync(plan.PlanId.ToString(), JsonSerializer.Serialize(plan), cancellationToken);

            return true;
        }

        public async Task<PlanResponseDto> CreatePlan(Plan plan, CancellationToken cancellationToken = default)
        {
            await repository.CreatePlan(plan, cancellationToken);

            await cache.SetStringAsync(plan.Id.ToString(), JsonSerializer.Serialize(plan), cancellationToken);

            return new PlanResponseDto(plan.Id, new List<Guid>());
        }

        public async Task<PlanResponseDto> GetPlan(Guid planId, CancellationToken cancellationToken = default)
        {
            var cachedPlan = await cache.GetStringAsync(planId.ToString(), cancellationToken);
            if (!string.IsNullOrEmpty(cachedPlan))
                return JsonSerializer.Deserialize<PlanResponseDto>(cachedPlan)!;

            var plan = await repository.GetPlan(planId, cancellationToken);
            await cache.SetStringAsync(planId.ToString(), JsonSerializer.Serialize(plan), cancellationToken);
            return plan;
        }

        public async Task<List<PlanResponseDto>> GetPlansByUserId(Guid userId, CancellationToken cancellation = default)
        {
            return await repository.GetPlansByUserId(userId, cancellation);
        }

        public async Task<bool> RemoveMember(Guid planId, Guid userId, CancellationToken cancellationToken = default)
        {
            await repository.RemoveMember(planId, userId, cancellationToken);

            var plan = await repository.GetPlan(planId, cancellationToken);

            await cache.SetStringAsync(planId.ToString(), JsonSerializer.Serialize(plan), cancellationToken);

            return true;
        }
    }
}
