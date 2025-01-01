namespace PostManagement.Domain.Events
{
    public record PostUpdatedEvent(Post Post, List<PostImage> RemovedImages, List<FileImg>? Images) : IDomainEvent;
}
