namespace TravelPlan.Domain.Events.Plans
{
    public record UploadImageEvent(Plan Plan, FileImg Avatar) : IDomainEvent;
}
