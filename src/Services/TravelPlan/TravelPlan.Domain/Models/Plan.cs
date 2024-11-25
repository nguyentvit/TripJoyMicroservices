namespace TravelPlan.Domain.Models
{
    public class Plan : Aggregate<PlanId>
    {
        private readonly List<PlanMember> _planMembers = new();
        private readonly List<PlanInvitation> _planInvitations = new();
        private readonly List<PlanLocationId> _planLocationIds = new();
        public IReadOnlyList<PlanMember> PlanMembers => _planMembers.AsReadOnly();
        public IReadOnlyList<PlanInvitation> PlanInvitations => _planInvitations.AsReadOnly();
        public IReadOnlyList<PlanLocationId> PlanLocationIds => _planLocationIds.AsReadOnly();
        public Title Title { get; private set; } = default!;
        public Image? Avatar { get; private set; }
        public Date StartDate { get; private set; } = default!;
        public Date EndDate { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public Money EstimatedBudget { get; private set; } = default!;
        public ProvinceId ProvinceStartId { get; private set; } = default!;
        public ProvinceId ProvinceEndId { get; private set; } = default!;
        public PlanVehicle Vehicle { get; private set; } = default!;
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
            CreationMethod method,
            PlanVehicle vehicle,
            ProvinceId provinceStartId,
            ProvinceId provinceEndId)
        {
            Id = id;
            Title = title;
            Avatar = avatar;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedBudget = estimatedBudget;
            Method = method;
            ProvinceStartId = provinceStartId;
            ProvinceEndId = provinceEndId;
            Vehicle = vehicle;
        }
        public static Plan Of(
            Title title, 
            Image? avatar, 
            Date startDate, 
            Date endDate, 
            Money estimatedBudget,
            CreationMethod method,
            PlanVehicle vehicle,
            ProvinceId provinceStartId,
            ProvinceId provinceEndId,
            UserId userId)
        {
            var plan = new Plan(
                id: PlanId.Of(Guid.NewGuid()),
                title: title,
                avatar: avatar,
                startDate: startDate,
                endDate: endDate,
                estimatedBudget: estimatedBudget,
                method: method,
                vehicle: vehicle,
                provinceStartId: provinceStartId,
                provinceEndId: provinceEndId
                );

            var planMember = PlanMember.Of(userId, MemberRole.Lead);

            plan.Note = Note.Of(string.Empty);
            plan.Status = PlanStatus.NotStarted;
            plan._planMembers.Add(planMember);

            return plan;
        }
        public void UpdatePlan(
            Title title, 
            Image? avatar, 
            Date startDate, 
            Date endDate, 
            Money estimatedBudget, 
            ProvinceId provinceStartId, 
            ProvinceId provinceEndId,
            PlanVehicle vehicle,
            UserId userId)
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
            ProvinceStartId = provinceStartId;
            ProvinceEndId = provinceEndId;
            Vehicle = vehicle;
        }
        public void InviteMember(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.InviteMember))
                throw new DomainException("You are not allowed to add member to the plan.");

            if (_planMembers.Any(m => m.MemberId == targetUserId))
                throw new DomainException("User is already existed in the plan");

            if (_planInvitations.Any(m => m.InviteeId == targetUserId))
                throw new DomainException("User is already existed in the planInvitations");

            var planInvitation = PlanInvitation.Of(userId, targetUserId);
            _planInvitations.Add(planInvitation);
        }
        public void RevokeInvitationMember(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.RevokeInvitationMember))
                throw new DomainException("You are not allowed to revoke invitation member");

            var planInvitation = _planInvitations.FirstOrDefault(m => m.InviteeId == targetUserId);
            if (planInvitation != null)
                _planInvitations.Remove(planInvitation);
        }
        public void AcceptInvitationMember(UserId userId)
        {
            if (_planMembers.Any(pi => pi.MemberId == userId))
                throw new DomainException($"{userId.Value} existed in plan");

            var planInvitation = _planInvitations.Where(pi => pi.InviteeId == userId).FirstOrDefault();

            if (planInvitation == null)
                throw new DomainException($"{userId.Value} not found in PlanInvitations");

            _planInvitations.Remove(planInvitation);
            var planMember = PlanMember.Of(userId, MemberRole.Member);
            _planMembers.Add(planMember);
        }
        public void DeclineInvitationMember(UserId userId)
        {
            var planInvitation = _planInvitations.Where(pi => pi.InviteeId == userId).FirstOrDefault();
            if (planInvitation != null)
                _planInvitations.Remove(planInvitation);
        }
        public void RemoveMember(UserId userId, UserId targetMemberId)
        {
            if (!HasPermission(userId, PlanPermission.RemoveMember, targetMemberId))
                throw new DomainException("You are not allowed to remove member from the plan.");

            var planMember = _planMembers.FirstOrDefault(m => m.MemberId == targetMemberId);
            if (planMember != null)
                _planMembers.Remove(planMember);
        }
        public void ChangePermission(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.ChangePermission))
                throw new DomainException("You are not allowed to grant permission. Only Lead can grant permission.");

            var planMember = _planMembers.FirstOrDefault(m => m.MemberId == targetUserId);
            if (planMember == null)
                throw new DomainException("Member isn't in the plan");
            if (planMember.Role == MemberRole.Lead)
                throw new DomainException("Member is Lead so don't change");

            planMember.ChangeRole();
        }
        public void EditNote(UserId userId, Note note)
        {
            if (!HasPermission(userId, PlanPermission.EditNote))
                throw new DomainException("You do not have permission to manage notes.");

            Note = note;
        }
        public void AddPlanLocation(UserId userId, PlanLocationId planLocationId)
        {
            if (!HasPermission(userId, PlanPermission.AddPlanLocation))
                throw new DomainException("You do not have permission to manage notes.");

            _planLocationIds.Add(planLocationId);
        }
        public void ChangeOrderPlanLocation(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.ChangeOrderPlanLocation))
                throw new DomainException("You do not have permission to change order plan location.");
        }
        public void AccessPlan(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
        }
        public void AddPlanLocationExpense(UserId userId, List<UserId> addPlanLocationExpenseIds)
        {
            if (!HasPermission(userId, PlanPermission.AddPlanLocationExpense))
                throw new DomainException("You do not have permission to add plan location expense");


            var memberIds = _planMembers.Select(pm => pm.MemberId).ToList();
            var invalidIds = addPlanLocationExpenseIds.Where(id => !memberIds.Contains(id)).ToList();

            if (invalidIds.Count > 0)
                throw new DomainException($"The following users are not members of the plan: {string.Join(", ", invalidIds)}");
        }
        public void StartPlan(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.StartPlan))
                throw new DomainException("You are not have permission to start the plan");

            if (Status != PlanStatus.NotStarted || Status != PlanStatus.Cancelled)
                throw new DomainException($"Status of plan is {Status} so cannot start");

            Status = PlanStatus.InProgress;
        }
        public void PausePlan(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.PausePlan))
                throw new DomainException("You are not have permission to pause the plan");

            if (Status != PlanStatus.InProgress)
                throw new DomainException($"Status of plan is {Status} so cannot pause");

            Status = PlanStatus.Cancelled;
        }
        private bool HasPermission(UserId userId, PlanPermission permission, UserId? targetMemberId = null)
        {
            var member = _planMembers.FirstOrDefault(m => m.MemberId == userId);
            if (member == null) return false;

            return permission switch
            { 
                PlanPermission.AccessPlan => true,
                PlanPermission.UpdatePlan => member.Role == MemberRole.Lead,
                PlanPermission.InviteMember => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                PlanPermission.RemoveMember => CanRemoveMember(member, targetMemberId),
                PlanPermission.ChangePermission => member.Role == MemberRole.Lead,
                PlanPermission.EditNote => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                PlanPermission.AddPlanLocation => member.Role == MemberRole.Lead,
                PlanPermission.ChangeOrderPlanLocation => member.Role == MemberRole.Lead,
                PlanPermission.AddPlanLocationExpense => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                PlanPermission.RevokeInvitationMember => member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead,
                PlanPermission.StartPlan =>  member.Role == MemberRole.Lead,
                PlanPermission.PausePlan => member.Role == MemberRole.Lead,
                _ => false
            };
        }
        private bool CanRemoveMember(PlanMember member, UserId? targetMemberId)
        {
            if (targetMemberId == null) return false;

            var targetMember = _planMembers.FirstOrDefault(m => m.MemberId == targetMemberId);
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
