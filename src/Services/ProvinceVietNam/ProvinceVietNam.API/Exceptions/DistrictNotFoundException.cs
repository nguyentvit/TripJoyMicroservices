namespace ProvinceVietNam.API.Exceptions
{
    public class DistrictNotFoundException : NotFoundException
    {
        public DistrictNotFoundException(string Code) : base("District", Code) { }
    }
}
