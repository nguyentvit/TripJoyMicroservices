namespace PostManagement.Domain.Events
{
    public record AddImagesEvent(Post Post, List<FileImg> Images) : IDomainEvent;
}
