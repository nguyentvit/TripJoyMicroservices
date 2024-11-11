using BuildingBlocks.Exceptions;

namespace LocationAttraction.Application.Exceptions
{
    public class LocationCategoryNotFoundException : NotFoundException
    {
        public LocationCategoryNotFoundException(Guid Id) : base("LocationCategory with LocationCategoryId", Id)
        {

        }
    }
}
