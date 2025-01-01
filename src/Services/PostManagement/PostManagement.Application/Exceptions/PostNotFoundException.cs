namespace PostManagement.Application.Exceptions
{
    public class PostNotFoundException : NotFoundException
    {
        public PostNotFoundException(Guid Id) : base("Post with PostId", Id)
        {

        }
    }
}
