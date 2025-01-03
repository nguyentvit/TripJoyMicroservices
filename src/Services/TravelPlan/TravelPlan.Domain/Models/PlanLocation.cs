﻿using TravelPlan.Domain.Events.PlanLocations;

namespace TravelPlan.Domain.Models
{
    public class PlanLocation : Aggregate<PlanLocationId>
    {
        private readonly List<PlanLocationImage> _images = new();
        private readonly List<PlanLocationUserSpender> _planLocationUserSpenders = new();
        public IReadOnlyList<PlanLocationImage> Images => _images.AsReadOnly();
        public IReadOnlyList<PlanLocationUserSpender> PlanLocationUserSpenders => _planLocationUserSpenders.AsReadOnly();
        public LocationId LocationId { get; private set; } = default!;
        public Coordinates Coordinates { get; private set; } = default!;
        public PlanId PlanId { get; private set; } = default!;
        public Note Note { get; private set; } = default!;
        public PlanLocationOrder Order { get; private set; } = default!;
        public Date EstimatedStartDate { get; private set; } = default!;
        public Date? CompletionDate { get; private set; }
        public PlanLocationStatus Status { get; private set; } = default!;
        public UserId? PayerId { get; private set; }
        public Money? Amount { get; private set; }
        private PlanLocation() { }
        private PlanLocation(
            PlanLocationId id,
            PlanId planId,
            LocationId locationId,
            Date estimatedStartDate,
            Coordinates coordinates,
            PlanLocationOrder order
            )
        {
            Id = id;
            PlanId = planId;
            LocationId = locationId;
            Coordinates = coordinates;
            Order = order;
            Status = PlanLocationStatus.NotStarted;
            EstimatedStartDate = estimatedStartDate;
            Note = Note.Of(string.Empty);
        }
        public static PlanLocation Of(PlanId planId, LocationId locationId, Date estimatedStartDate, Coordinates coordinates, PlanLocationOrder order)
        {
            return new PlanLocation(
                id: PlanLocationId.Of(Guid.NewGuid()),
                planId: planId,
                locationId: locationId,
                estimatedStartDate: estimatedStartDate,
                coordinates: coordinates,
                order: order
                );
        }
        public void ChangeOrder(PlanLocationOrder order)
        {
            Order = order;
        }
        public void ChangeOrderAndDate(PlanLocationOrder order, Date estimatedStartDate)
        {
            Order = order;
            EstimatedStartDate = estimatedStartDate;
        }
        public void AddPlanLocationExpense(List<UserId> planLocationUserSpenders, UserId payerId, Money amount)
        {
            _planLocationUserSpenders.Clear();
            foreach (var planLocationUserSpender in  planLocationUserSpenders)
            {
                _planLocationUserSpenders.Add(PlanLocationUserSpender.Of(planLocationUserSpender));
            }

            PayerId = payerId;
            Amount = amount;
        }
        public bool ExistUserIdInUserSpender(UserId userId)
        {
            return _planLocationUserSpenders.Any(spender => spender.UserSpenderId == userId);
        }

        public void EditNotePlanLocation(Note note)
        {
            Note = note;
        }
        public void AddImagePlanLocation(FileImg image, UserId userId)
        {
            AddDomainEvent(new AddImagePlanLocationEvent(this, userId, image));
        }
        public void AddImagePlanLocationHandler(Image image, UserId userId)
        {
            var planLocationImage = PlanLocationImage.Of(userId, image, Title.Of("image"));
            _images.Add(planLocationImage);
        }
        public void RemoveImagePlanLocation(Image image)
        {
            if (_images.Any(i => i.Image == image))
            {
                AddDomainEvent(new RemoveImagePlanLocationEvent(this, image));
            }
        }
        public void RemoveImagePlanLocationHandler(Image image)
        {
            var planLocationImage = _images.FirstOrDefault(i => i.Image == image);  
            if (planLocationImage != null)
            {
                _images.Remove(planLocationImage);
            }
        }
    }
}
