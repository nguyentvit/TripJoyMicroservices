namespace ProvinceVietNam.API.Districts.GetDistricts
{
    public record GetDistrictsQuery() : IQuery<GetDistrictsResult>;
    public record GetDistrictsResult(IEnumerable<District> Districts);
    internal class GetDistrictsHandler(
        ProvincedbContext dbContext,
        ILogger<GetDistrictsHandler> logger
        )
        : IRequestHandler<GetDistrictsQuery, GetDistrictsResult>
    {
        public async Task<GetDistrictsResult> Handle(GetDistrictsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetDistrictsHandler.Handle called with {@Query}", query);

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
                .ToListAsync(cancellationToken);

            return new GetDistrictsResult(district);
        }
    }
}
