namespace ProvinceVietNam.API.Wards.GetWards
{
    public record GetWardsQuery() : IQuery<GetWardsResult>;
    public record GetWardsResult(IEnumerable<Ward> Wards);
    internal class GetWardsHandler(
        ProvincedbContext dbContext
        )
        : IRequestHandler<GetWardsQuery, GetWardsResult>
    {
        public async Task<GetWardsResult> Handle(GetWardsQuery query, CancellationToken cancellationToken)
        {
            var wards = await dbContext.Wards
                .Select(w => new Ward
                {
                    Code = w.Code,
                    Name = w.Name,
                    NameEn = w.NameEn,
                    FullName = w.FullName,
                    FullNameEn = w.FullNameEn,
                    CodeName = w.CodeName,
                    DistrictCode = w.DistrictCode,
                    AdministrativeUnit = w.AdministrativeUnit,
                    AdministrativeUnitId = w.AdministrativeUnitId,
                    DistrictCodeNavigation = w.DistrictCodeNavigation,
                })
                .ToListAsync(cancellationToken);

            return new GetWardsResult(wards);
        }
    }
}
