namespace ProvinceVietNam.API.Exceptions
{
    public class WardNotFoundException : NotFoundException
    {
        public WardNotFoundException(string Code) : base("Ward", Code) { }
    }
}
