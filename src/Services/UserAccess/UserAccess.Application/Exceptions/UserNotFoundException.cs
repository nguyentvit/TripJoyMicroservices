using BuildingBlocks.Exceptions;

namespace UserAccess.Application.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string Id) : base("User with AccountId", Id)
        {

        }
    }
}
