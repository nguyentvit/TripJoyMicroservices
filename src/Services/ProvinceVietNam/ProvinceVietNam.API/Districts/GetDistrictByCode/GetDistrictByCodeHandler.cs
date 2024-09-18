namespace ProvinceVietNam.API.Districts.GetDistrictByCode
{
    public record GetDistrictByCodeQuery(string Code) : IQuery<GetDistrictByCodeResult>;
    public record GetDistrictByCodeResult(District District);
    internal class GetDistrictByCodeHandler(
        ProvincedbContext dbContext
        )
        : IRequestHandler<GetDistrictByCodeQuery, GetDistrictByCodeResult>
    {
        public async Task<GetDistrictByCodeResult> Handle(GetDistrictByCodeQuery query, CancellationToken cancellationToken)
        {
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
                throw new DistrictNotFoundException(query.Code);
            }

            return new GetDistrictByCodeResult(district);
        }
    }
}
