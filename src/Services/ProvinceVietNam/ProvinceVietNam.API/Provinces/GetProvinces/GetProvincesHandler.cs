namespace ProvinceVietNam.API.Provinces.GetProvinces
{
    public record GetProvincesQuery() : IQuery<GetProvincesResult>;
    public record GetProvincesResult(IEnumerable<Province> Provinces);
    internal class GetProvincesHandler(
        ProvincedbContext dbContext,
        ILogger<GetProvincesHandler> logger
        )
        : IRequestHandler<GetProvincesQuery, GetProvincesResult>
    {
        public async Task<GetProvincesResult> Handle(GetProvincesQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProvincesQueryHanler.Handle called with {@Query}", query);

            var provinces = await dbContext.Provinces
                .Select(p => new Province
                {
                    Code = p.Code,
                    Name = p.Name,
                    NameEn = p.NameEn,
                    FullName = p.FullName,
                    FullNameEn = p.FullNameEn,
                    CodeName = p.CodeName,
                    AdministrativeUnitId = p.AdministrativeUnitId,
                    AdministrativeRegionId = p.AdministrativeRegionId,
                    AdministrativeRegion = p.AdministrativeRegion,
                    AdministrativeUnit = p.AdministrativeUnit,
                    Districts = p.Districts
                })
                .ToListAsync(cancellationToken);

            return new GetProvincesResult(provinces);
        }
    }
}
