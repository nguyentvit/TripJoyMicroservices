namespace ProvinceVietNam.API.Provinces.GetProvinceByCode
{
    public record GetProvinceByCodeQuery(string Code) : IQuery<GetProvinceByCodeResult>;
    public record GetProvinceByCodeResult(Province Province);
    internal class GetProvinceByCodeHandler(
        ProvincedbContext dbContext,
        ILogger<GetProvinceByCodeHandler> logger
        )
        : IRequestHandler<GetProvinceByCodeQuery, GetProvinceByCodeResult>
    {
        public async Task<GetProvinceByCodeResult> Handle(GetProvinceByCodeQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProvinceByCodeHandler.Handle called with {@Query}", query);

            var province = await dbContext.Provinces
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
                .FirstOrDefaultAsync(p => p.Code == query.Code);

            if (province == null )
            {
                throw new ProvinceNotFoundException();
            }

            return new GetProvinceByCodeResult(province);
        }
    }
}
