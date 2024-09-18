namespace ProvinceVietNam.API.Exceptions
{
    public class AdministrativeUnitNotFoundException : NotFoundException
    {
        public AdministrativeUnitNotFoundException(int Id) : base("AdministrativeUnit", Id) { }
    }
}
