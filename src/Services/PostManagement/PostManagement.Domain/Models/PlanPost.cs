namespace PostManagement.Domain.Models
{
    public class PlanPost : Post
    {
        private readonly List<PostPlanLocation> _postPlanLocations = new();
        public IReadOnlyList<PostPlanLocation> PostPlanLocations => _postPlanLocations.AsReadOnly();
        public PlanId PlanId { get; private set; } = default!;
        public Date PlanStartDate { get; private set; } = default!;
        public Date PlanEndDate { get; private set; } = default!;
        public Money Budget { get; private set; } = default!;
        public Province ProvinceStart { get; private set; } = default!;
        public Province ProvinceEnd { get; private set; } = default!;
        public PlanVehicle Vehicle { get; private set; } = default!;
        private PlanPost() { }
        private PlanPost(PostId id, UserId userId, Content content, PostType postType, PlanId planId, Date startDate, Date endDate, Money budget, Province provinceStart, Province provinceEnd, PlanVehicle vehicle, List<FileImg>? images, List<PostPlanLocation>? postPlanLocations) : base(id, userId, content, postType, images)
        {
            PlanId = planId;
            PlanStartDate = startDate;
            PlanEndDate = endDate;
            Budget = budget;
            ProvinceStart = provinceStart;
            ProvinceEnd = provinceEnd;
            Vehicle = vehicle;

            if (postPlanLocations is not null)
            {
                _postPlanLocations.AddRange(postPlanLocations);
            }
        }
        public static PlanPost CreatePlanPost(UserId userId, Content content, PlanId planId, Date startDate, Date endDate, Money budget, Province provinceStart, Province provinceEnd, PlanVehicle vehicle, List<FileImg>? images, List<PostPlanLocation>? postPlanLocations)
        {
            var planPost = new PlanPost(PostId.Of(Guid.NewGuid()), userId, content, PostType.Plan, planId, startDate, endDate, budget, provinceStart, provinceEnd, vehicle, images, postPlanLocations);

            return planPost;
        }
    }
}
