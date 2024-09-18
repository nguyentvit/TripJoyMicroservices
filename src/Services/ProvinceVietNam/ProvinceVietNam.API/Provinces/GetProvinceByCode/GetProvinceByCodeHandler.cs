namespace ProvinceVietNam.API.Provinces.GetProvinceByCode
{
    public record GetProvinceByCodeQuery(string Code) : IQuery<GetProvinceByCodeResult>;
    public record GetProvinceByCodeResult(Province Province);
    internal class GetProvinceByCodeHandler(
        ProvincedbContext dbContext
        )
        : IRequestHandler<GetProvinceByCodeQuery, GetProvinceByCodeResult>
    {
        public async Task<GetProvinceByCodeResult> Handle(GetProvinceByCodeQuery query, CancellationToken cancellationToken)
        {
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
                throw new ProvinceNotFoundException(query.Code);
            }

            return new GetProvinceByCodeResult(province);
        }
    }
}
