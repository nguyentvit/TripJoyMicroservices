namespace ProvinceVietNam.API.AdministrativeUnits.GetAdministrativeUnitById
{
    public record GetAdministrativeUnitByIdQuery(int Id) : IQuery<GetAdministrativeUnitByIdResult>;
    public record GetAdministrativeUnitByIdResult(AdministrativeUnit AdministrativeUnit);
    internal class GetAdministrativeUnitByIdHandler(
        ProvincedbContext dbContext,
        ILogger<GetAdministrativeUnitByIdHandler> logger
        )
        : IRequestHandler<GetAdministrativeUnitByIdQuery, GetAdministrativeUnitByIdResult>
    {
        public async Task<GetAdministrativeUnitByIdResult> Handle(GetAdministrativeUnitByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetAdministrativeUnitByIdHandler.Handle called with {@Query}", query);

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
                throw new AdministrativeUnitNotFoundException();
            }

            return new GetAdministrativeUnitByIdResult(administrativeUnit);

        }
    }
}
