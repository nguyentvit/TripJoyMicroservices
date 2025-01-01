using TravelPlan.Domain.Events.Plans;

namespace TravelPlan.Domain.Models
{
    public class Plan : Aggregate<PlanId>
    {
        private readonly List<PlanMember> _planMembers = new();
        private readonly List<PlanInvitation> _planInvitations = new();
        private readonly List<PlanLocationId> _planLocationIds = new();
        private readonly List<PlanJoinRequest> _planJoinRequests = new();
        public IReadOnlyList<PlanMember> PlanMembers => _planMembers.AsReadOnly();
        public IReadOnlyList<PlanInvitation> PlanInvitations => _planInvitations.AsReadOnly();
        public IReadOnlyList<PlanLocationId> PlanLocationIds => _planLocationIds.AsReadOnly();
        public IReadOnlyList<PlanJoinRequest> PlanJoinRequests => _planJoinRequests.AsReadOnly();
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
        public PlanJoinStatus JoinStatus { get; private set; }
        private Plan() { }
        private Plan(
            PlanId id,
            Title title,
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
            StartDate = startDate;
            EndDate = endDate;
            EstimatedBudget = estimatedBudget;
            Method = method;
            ProvinceStartId = provinceStartId;
            ProvinceEndId = provinceEndId;
            Vehicle = vehicle;
            Note = Note.Of(string.Empty);
            Status = PlanStatus.NotStarted;
            JoinStatus = PlanJoinStatus.NotAllow;
        }
        public static Plan Of(
            Title title, 
            Date startDate, 
            Date endDate, 
            Money estimatedBudget,
            CreationMethod method,
            PlanVehicle vehicle,
            ProvinceId provinceStartId,
            ProvinceId provinceEndId,
            UserId userId,
            FileImg? avatar)
        {
            var plan = new Plan(
                id: PlanId.Of(Guid.NewGuid()),
                title: title,
                startDate: startDate,
                endDate: endDate,
                estimatedBudget: estimatedBudget,
                method: method,
                vehicle: vehicle,
                provinceStartId: provinceStartId,
                provinceEndId: provinceEndId
                );

            var planMember = PlanMember.Of(userId, MemberRole.Lead);
            plan._planMembers.Add(planMember);


            if (avatar != null)
            {
                plan.AddDomainEvent(new UploadImageEvent(plan, avatar));
            }

            return plan;
        }
        public void UpdateAvatar(Image avatar)
        {
            Avatar = avatar;
        }
        public void UpdatePlan(
            Title title,
            Date startDate, 
            Date endDate, 
            Money estimatedBudget, 
            ProvinceId provinceStartId, 
            ProvinceId provinceEndId,
            PlanVehicle vehicle,
            UserId userId,
            FileImg? avatar)
        {
            if (!HasPermission(userId, PlanPermission.AccessPlan))
                throw new DomainException("You do not have access to this plan.");
            if (!HasPermission(userId, PlanPermission.UpdatePlan))
                throw new DomainException("You are not allowed to update the plan.");

            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedBudget = estimatedBudget;
            ProvinceStartId = provinceStartId;
            ProvinceEndId = provinceEndId;
            Vehicle = vehicle;

            if (avatar != null)
            {
                AddDomainEvent(new UploadImageEvent(this, avatar));
            }
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

            if (planMember != null && planMember.Role == MemberRole.Lead)
                throw new DomainException("You are not allowed to remove member with role is lead.");

            if (planMember != null)
                _planMembers.Remove(planMember);
        }
        public void LeavePlan(UserId userId)
        {
            var planMember = _planMembers.FirstOrDefault(m => m.MemberId == userId);

            if (planMember != null && planMember.Role == MemberRole.Lead)
                throw new DomainException("You are not allowed to leave plan with role is lead.");

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
        public void AcceptJoinPlanRequest(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.AcceptJoinPlanRequest))
                throw new DomainException("You do not have permission to accept join plan request");

            var planJoinRequestExisted = _planJoinRequests.FirstOrDefault(j => j.UserId == targetUserId);
            if (planJoinRequestExisted == null)
                throw new DomainException("Join plan request with userId not found");

            _planJoinRequests.Remove(planJoinRequestExisted);
            if (!_planMembers.Any(m => m.MemberId == targetUserId))
            {
                var planMember = PlanMember.Of(targetUserId, MemberRole.Member);
                _planMembers.Add(planMember);
            }
        }
        public void DeclineJoinPlanRequest(UserId userId, UserId targetUserId)
        {
            if (!HasPermission(userId, PlanPermission.DeclineJoinPlanRequest))
                throw new DomainException("You do not have permission to decline join plan request");

            var planJoinRequestExisted = _planJoinRequests.FirstOrDefault(j => j.UserId == targetUserId);
            if (planJoinRequestExisted == null)
                throw new DomainException("Join plan request with userId not found");

            _planJoinRequests.Remove(planJoinRequestExisted);
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

            if (Status == PlanStatus.InProgress)
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

        public void CompletePlan(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.CompletePlan))
                throw new DomainException("You are not have permission to complete the plan");

            if (Status != PlanStatus.InProgress)
                throw new DomainException($"Status of plan is {Status} to cannot complete");

            Status = PlanStatus.Completed;
        }
        public void EditPlanLocation(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.EditPlanLocation))
                throw new DomainException("You are not have permission to edit in the plan location");
        }

        public void RemovePlanLocation(UserId userId, PlanLocation planLocation)
        {
            if (!HasPermission(userId, PlanPermission.RemovePlanLocation))
                throw new DomainException("You are not have permission to remove plan location");

            _planLocationIds.Remove(planLocation.Id);

            AddDomainEvent(new RemovePlanLocationEvent(this, planLocation));
        }
        public void ChangePlanJoinStatus(UserId userId)
        {
            if (!HasPermission(userId, PlanPermission.ChangePlanJoinStatus))
                throw new DomainException("You are not have permission to change plan join status");

            if (JoinStatus == PlanJoinStatus.Allow)
            { 
                JoinStatus = PlanJoinStatus.NotAllow; 
            }
            else
            {
                JoinStatus = PlanJoinStatus.Allow;
            }
        }
        public void JoinRequestPlan(PlanJoinRequest joinRequest)
        {
            if (JoinStatus == PlanJoinStatus.NotAllow)
                throw new DomainException("Plan is already not allow to join");

            if (_planMembers.Any(m => m.MemberId == joinRequest.UserId))
                throw new DomainException("You are already in member list");

            if (_planInvitations.Any(i => i.InviteeId == joinRequest.UserId))
                throw new DomainException("This plan invited me");

            if (_planJoinRequests.Any(j => j.UserId == joinRequest.UserId))
                throw new DomainException("You applied this plan");

            _planJoinRequests.Add(joinRequest);
        }
        public void RevokeJoinRequestPlan(UserId userId)
        {
            var planJoinRequestExisted = _planJoinRequests.FirstOrDefault(j => j.UserId == userId);
            if (planJoinRequestExisted != null)
                _planJoinRequests.Remove(planJoinRequestExisted);
        }
        private bool HasPermission(UserId userId, PlanPermission permission, UserId? targetMemberId = null)
        {
            var member = _planMembers.FirstOrDefault(m => m.MemberId == userId);
            if (member == null) return false;

            return permission switch
            { 
                PlanPermission.AccessPlan => true,
                PlanPermission.UpdatePlan => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.InviteMember =>(member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.RemoveMember => CanRemoveMember(member, targetMemberId) && Status != PlanStatus.Completed,
                PlanPermission.ChangePermission => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.EditNote => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.AddPlanLocation => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.ChangeOrderPlanLocation => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.AddPlanLocationExpense => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.RevokeInvitationMember => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.StartPlan =>  member.Role == MemberRole.Lead,
                PlanPermission.PausePlan => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.EditPlanLocation => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.RemovePlanLocation => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.ChangePlanJoinStatus => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
                PlanPermission.AcceptJoinPlanRequest => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.DeclineJoinPlanRequest => (member.Role == MemberRole.Lead || member.Role == MemberRole.CoLead) && Status != PlanStatus.Completed,
                PlanPermission.CompletePlan => member.Role == MemberRole.Lead && Status != PlanStatus.Completed,
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
