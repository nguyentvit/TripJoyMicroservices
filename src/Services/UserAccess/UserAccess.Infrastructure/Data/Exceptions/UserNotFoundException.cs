using BuildingBlocks.Exceptions;

namespace UserAccess.Infrastructure.Data.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string Id) : base("User with AccountId", Id)
        {

        }
    }
}
