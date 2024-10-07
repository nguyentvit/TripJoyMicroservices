using BuildingBlocks.Exceptions;

namespace UserAccess.Application.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid Id) : base("User", Id)
        {

        }
    }
}
