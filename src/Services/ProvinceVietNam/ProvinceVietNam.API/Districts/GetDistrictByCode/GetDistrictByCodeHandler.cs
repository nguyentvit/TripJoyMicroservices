namespace ProvinceVietNam.API.Districts.GetDistrictByCode
{
    public record GetDistrictByCodeQuery(string Code) : IQuery<GetDistrictByCodeResult>;
    public record GetDistrictByCodeResult(District District);
    internal class GetDistrictByCodeHandler(
        ProvincedbContext dbContext,
        ILogger<GetDistrictByCodeHandler> logger
        )
        : IRequestHandler<GetDistrictByCodeQuery, GetDistrictByCodeResult>
    {
        public async Task<GetDistrictByCodeResult> Handle(GetDistrictByCodeQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetDistrictByCodeHandler.Handle called with {@Query}", query);

            var district = await dbContext.Districts
                .Select(d => new District
                {
                    Code = d.Code,
                    Name = d.Name,
                    NameEn = d.NameEn,
                    FullName = d.FullName,
                    FullNameEn = d.FullNameEn,
                    CodeName = d.CodeName,
                    ProvinceCode = d.ProvinceCode,
                    AdministrativeUnitId = d.AdministrativeUnitId,
                    AdministrativeUnit = d.AdministrativeUnit,
                    ProvinceCodeNavigation = d.ProvinceCodeNavigation,
                    Wards = d.Wards,
                })
                .FirstOrDefaultAsync(d => d.Code == query.Code);

            if (district == null)
            {
                throw new DistrictNotFoundException();
            }

            return new GetDistrictByCodeResult(district);
        }
    }
}
