namespace TravelPlan.Domain.Entities
{
    public class PlanMember : Entity<PlanMemberId>
    {
        public UserId MemberId { get; private set; } = default!;
        public MemberRole Role { get; private set; } = default!;
        private PlanMember(PlanMemberId id, UserId memberId, MemberRole role)
        {
            Id = id;
            MemberId = memberId;
            Role = role;
        }
        private PlanMember() { }
        public static PlanMember Of(UserId memberId, MemberRole role)
        {
            if (memberId == null)
                throw new DomainException("MemberId cannot be null");
            if (!Enum.IsDefined(typeof(MemberRole), role))
                throw new DomainException("Invalid role");

            return new PlanMember(PlanMemberId.Of(Guid.NewGuid()), memberId, role);
        }
        public void ChangeRole(MemberRole role)
        {
            if (!Enum.IsDefined(typeof(MemberRole), role))
                throw new DomainException("Invalid role");
            Role = role;
        }

    }
}
