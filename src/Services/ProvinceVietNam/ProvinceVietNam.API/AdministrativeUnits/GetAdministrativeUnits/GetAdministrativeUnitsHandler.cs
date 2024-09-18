namespace ProvinceVietNam.API.AdministrativeUnits.GetAdministrativeUnits
{
    public record GetAdministrativeUnitsQuery() : IQuery<GetAdministrativeUnitsResult>;
    public record GetAdministrativeUnitsResult(IEnumerable<AdministrativeUnit> AdministrativeUnits);
    internal class GetAdministrativeUnitsHandler(
        ProvincedbContext dbContext
        )
        : IQueryHandler<GetAdministrativeUnitsQuery, GetAdministrativeUnitsResult>
    {
        public async Task<GetAdministrativeUnitsResult> Handle(GetAdministrativeUnitsQuery query, CancellationToken cancellationToken)
        {
            var administrativeUnits = await dbContext.AdministrativeUnits
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
                }).ToListAsync(cancellationToken);

            return new GetAdministrativeUnitsResult(administrativeUnits);
        }
    }
}
