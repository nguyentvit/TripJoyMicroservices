namespace ProvinceVietNam.API.AdministrativeRegions.GetAdministrativeRegions
{
    public record GetAdministrativeRegionsQuery() : IQuery<GetAdministrativeRegionsResult>;
    public record GetAdministrativeRegionsResult(IEnumerable<AdministrativeRegion> AdministrativeRegions);
    internal class GetAdministrativeRegionsQueryHandler(
        ILogger<GetAdministrativeRegionsQueryHandler> logger,
        ProvincedbContext dbContext
        )
        : IQueryHandler<GetAdministrativeRegionsQuery, GetAdministrativeRegionsResult>
    {
        public async Task<GetAdministrativeRegionsResult> Handle(GetAdministrativeRegionsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetAdministrativeRegionsQueryHandler.Handle called with {@Query}", query);

            var administrativeRegions = await dbContext.AdministrativeRegions
                .Select(ar => new AdministrativeRegion
            {
                Id = ar.Id,
                Name = ar.Name,
                NameEn = ar.NameEn,
                CodeName = ar.CodeName,
                CodeNameEn = ar.CodeNameEn,
                Provinces = ar.Provinces
            }).ToListAsync(cancellationToken);

            return new GetAdministrativeRegionsResult(administrativeRegions);

        }
    }
}
