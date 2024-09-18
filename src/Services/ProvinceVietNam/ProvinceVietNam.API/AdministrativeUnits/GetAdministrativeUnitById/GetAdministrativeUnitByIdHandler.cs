namespace ProvinceVietNam.API.AdministrativeUnits.GetAdministrativeUnitById
{
    public record GetAdministrativeUnitByIdQuery(int Id) : IQuery<GetAdministrativeUnitByIdResult>;
    public record GetAdministrativeUnitByIdResult(AdministrativeUnit AdministrativeUnit);
    internal class GetAdministrativeUnitByIdHandler(
        ProvincedbContext dbContext
        )
        : IRequestHandler<GetAdministrativeUnitByIdQuery, GetAdministrativeUnitByIdResult>
    {
        public async Task<GetAdministrativeUnitByIdResult> Handle(GetAdministrativeUnitByIdQuery query, CancellationToken cancellationToken)
        {
            var administrativeUnit = await dbContext.AdministrativeUnits
                .Select(au => new AdministrativeUnit
                {
                    Id = au.Id,
                    FullName = au.FullName,
                    FullNameEn = au.FullNameEn,
                    ShortName = au.ShortName,
                    ShortNameEn = au.ShortNameEn,
                    CodeName = au.CodeName,
                    CodeNameEn = au.CodeNameEn,
                    Provinces = au.Provinces,
                })
                .FirstOrDefaultAsync(au => au.Id == query.Id);

            if (administrativeUnit == null)
            {
                throw new AdministrativeUnitNotFoundException(query.Id);
            }

            return new GetAdministrativeUnitByIdResult(administrativeUnit);

        }
    }
}
