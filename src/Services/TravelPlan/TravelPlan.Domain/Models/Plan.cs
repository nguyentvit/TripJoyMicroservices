namespace TravelPlan.Domain.Models
{
    public class Plan : Aggregate<PlanId>
    {
        private readonly List<PlanMember> _members = new();
        private readonly List<PlanInvitation> _invitations = new();
        private readonly List<PlanLocationId> _planLocationIds = new();
        private readonly List<PlanVehicle> _vehicles = new();
        public IReadOnlyList<PlanMember> Members => _members.AsReadOnly();
        public IReadOnlyList<PlanInvitation> Invitations => _invitations.AsReadOnly();
        public IReadOnlyList<PlanLocationId> PlanLocationIds => _planLocationIds.AsReadOnly();
        public IReadOnlyList<PlanVehicle> Vehicles => _vehicles.AsReadOnly();
        public Title Title { get; private set; } = default!;
        public Image? Avatar { get; private set; }
        public Date StartDate { get; private set; } = default!;
        public Date EndDate { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public Money EstimatedBudget { get; private set; } = default!;
        public Visibility Visibility { get; private set; }
        public PlanStatus Status { get; private set; }
        public CreationMethod Method { get; private set; }
        private Plan() { }
        private Plan(
            PlanId id,
            Title title,
            Image? avatar,
            Date startDate,
            Date endDate,
            Money estimatedBudget,
            Visibility visibility,
            CreationMethod method)
        {
            Id = id;
            Title = title;
            Avatar = avatar;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedBudget = estimatedBudget;
            Visibility = visibility;
            Method = method;
        }
        public static Plan Of(Title title, Image? avatar, Date startDate, Date endDate, Money estimatedBudget, Visibility visibility, CreationMethod method, UserId userId)
        {
            var plan = new Plan(
                id: PlanId.Of(Guid.NewGuid()),
                title: title,
                avatar: avatar,
                startDate: startDate,
                endDate: endDate,
                estimatedBudget: estimatedBudget,
                visibility: visibility,
                method: method
                );

            plan.Note = Note.Of(string.Empty);
            var planMember = PlanMember.Of(userId, MemberRole.Lead);
            plan.AddLeadCreate(planMember);

            return plan;
        }
        public void UpdatePlan(Title title, Image? avatar, Date startDate, Date endDate, Money estimatedBudget, Visibility visibility, UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.UpdatePlan))
                throw new DomainException("You are not allowed to update the plan.");

            Title = title;
            if (avatar != null)
                Avatar = avatar;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedBudget = estimatedBudget;
            Visibility = visibility;
        }
        private void AddLeadCreate(PlanMember member)
        {
            _members.Add(member);
        }
        public void AddMember(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.AddMember))
                throw new DomainException("You are not allowed to add member to the plan.");

            if (_members.Any(m => m.MemberId == targetUserId))
                throw new DomainException("User is already existed in the plan");

            var planMember = PlanMember.Of(targetUserId, MemberRole.Member);
            _members.Add(planMember);
        }
        public void RemoveMember(UserId userId, UserId targetMemberId)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.RemoveMember, targetMemberId))
                throw new DomainException("You are not allowed to remove member from the plan.");

            var planMember = _members.FirstOrDefault(m => m.MemberId == targetMemberId);
            if (planMember != null)
                _members.Remove(planMember);
        }
        public void ChangePermission(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.ChangePermission))
                throw new DomainException("You are not allowed to grant permission. Only Lead can grant permission.");

            var planMember = _members.FirstOrDefault(m => m.MemberId == targetUserId);
            if (planMember == null)
                throw new DomainException("Member isn't in the plan");
            if (planMember.Role == MemberRole.Lead)
                throw new DomainException("Member is Lead so don't change");

            planMember.ChangeRole();
        }
        public void EditNote(UserId userId, Note note)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.EditNote))
                throw new DomainException("You do not have permission to manage notes.");

            Note = note;
        }
        private bool HasPermission(UserId userId, PlanPermission permission, UserId? targetMemberId = null)
        {
            var member = _members.FirstOrDefault(m => m.MemberId == userId);
            if (member == null) return false;

            return permission switch
            { 
                PlanPermission.AccessPlan => true,
                PlanPermission.UpdatePlan => member.Role == MemberRole.Lead,
                PlanPermission.AddMember => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                PlanPermission.RemoveMember => CanRemoveMember(member, targetMemberId),
                PlanPermission.ChangePermission => member.Role == MemberRole.Lead,
                PlanPermission.EditNote => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                _ => false
            };
        }
        private bool CanRemoveMember(PlanMember member, UserId? targetMemberId)
        {
            if (targetMemberId == null) return false;

            var targetMember = _members.FirstOrDefault(m => m.MemberId == targetMemberId);
            if (targetMember == null) return false;

            return member.Role switch
            {
                MemberRole.Lead => targetMember.Role == MemberRole.CoLead || targetMember.Role == MemberRole.Member,
                MemberRole.CoLead => targetMember.Role == MemberRole.Member,
                _ => false
            };
        }
    }
}
