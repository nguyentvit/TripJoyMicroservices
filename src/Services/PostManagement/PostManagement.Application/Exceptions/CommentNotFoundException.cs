namespace PostManagement.Application.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(Guid Id) : base("Comment with CommentId", Id)
        {

        }
    }
}
