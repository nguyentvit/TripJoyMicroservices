namespace ProvinceVietNam.API.Exceptions
{
    public class AdministrativeRegionNotFoundException :NotFoundException
    {
        public AdministrativeRegionNotFoundException(int Id) : base("AdministrativeRegion", Id) { }
    }
}
