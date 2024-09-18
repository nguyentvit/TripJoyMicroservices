namespace ProvinceVietNam.API.Wards.GetWardByCode
{
    public record GetWardByCodeQuery(string Code) : IQuery<GetWardByCodeResult>;
    public record GetWardByCodeResult(Ward Ward);
    internal class GetWardByCodeHandler(
        ProvincedbContext dbContext,
        ILogger<GetWardByCodeHandler> logger
        )
        : IRequestHandler<GetWardByCodeQuery, GetWardByCodeResult>
    {
        public async Task<GetWardByCodeResult> Handle(GetWardByCodeQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetWardByCodeHandler.Handle called with {@Query}", query);

            var ward = await dbContext.Wards
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
                .FirstOrDefaultAsync(w => w.Code == query.Code, cancellationToken);

            if (ward == null)
            {
                throw new WardNotFoundException();
            }

            return new GetWardByCodeResult(ward);
        }
    }
}
