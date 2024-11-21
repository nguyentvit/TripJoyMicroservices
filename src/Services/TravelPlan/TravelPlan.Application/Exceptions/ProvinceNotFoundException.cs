namespace TravelPlan.Application.Exceptions
{
    public class ProvinceNotFoundException : NotFoundException
    {
        public ProvinceNotFoundException(Guid Id) : base("Province with ProvinceId", Id)
        {

        }
    }
}
