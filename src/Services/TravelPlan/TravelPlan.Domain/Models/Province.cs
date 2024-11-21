namespace TravelPlan.Domain.Models
{
    public class Province : Aggregate<ProvinceId>
    {
        private readonly List<PlanId> _planIds = new();
        public IReadOnlyList<PlanId> PlanIds => _planIds.AsReadOnly();
        public ProvinceName Name { get; private set; } = default!;
        private Province() { }
        public Province(ProvinceId id, ProvinceName name)
        {
            Id = id;
            Name = name;
        }
    }
}
