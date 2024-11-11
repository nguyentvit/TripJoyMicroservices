using BuildingBlocks.Exceptions;

namespace LocationAttraction.Application.Exceptions
{
    public class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(Guid Id) : base("Location with LocationId", Id)
        {

        }
        public LocationNotFoundException(double latitude, double longitude) : base($"Location with coordinates {latitude}:{longitude}")
        {

        }
    }
}
