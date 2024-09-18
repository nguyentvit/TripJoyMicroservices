namespace ProvinceVietNam.API.Exceptions
{
    public class ProvinceNotFoundException : NotFoundException
    {
        public ProvinceNotFoundException(string Code) : base("Province", Code) { }
    }
}
