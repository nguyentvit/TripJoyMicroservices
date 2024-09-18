namespace ProvinceVietNam.API.AdministrativeRegions.GetAdministrativeRegionById
{
    public record GetAdministrativeRegionByIdQuery(int Id) : IQuery<GetAdministrativeRegionByIdResult>;
    public record GetAdministrativeRegionByIdResult(AdministrativeRegion AdministrativeRegion);
    internal class GetAdministrativeRegionByIdHandler(
        ProvincedbContext dbContext
        )
        : IQueryHandler<GetAdministrativeRegionByIdQuery, GetAdministrativeRegionByIdResult>
    {
        public async Task<GetAdministrativeRegionByIdResult> Handle(GetAdministrativeRegionByIdQuery query, CancellationToken cancellationToken)
        {
            var administrativeRegion = await dbContext.AdministrativeRegions
                .Select(ar => new AdministrativeRegion
            {
                Id = ar.Id,
                Name = ar.Name,
                NameEn = ar.NameEn,
                CodeName = ar.CodeName,
                CodeNameEn = ar.CodeNameEn,
                Provinces = ar.Provinces
            }).FirstOrDefaultAsync(ar => ar.Id == query.Id);

            
            if (administrativeRegion == null)
            {
                throw new AdministrativeRegionNotFoundException(query.Id);
            }

            return new GetAdministrativeRegionByIdResult(administrativeRegion);
        }
    }
}
