namespace UserAccess.Domain.Events
{
    public record UploadImageEvent(User User, FileImg Avatar) : IDomainEvent;
}
