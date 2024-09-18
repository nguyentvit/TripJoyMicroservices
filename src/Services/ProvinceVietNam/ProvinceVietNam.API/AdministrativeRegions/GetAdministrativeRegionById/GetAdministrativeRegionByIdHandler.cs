﻿namespace ProvinceVietNam.API.AdministrativeRegions.GetAdministrativeRegionById
{
    public record GetAdministrativeRegionByIdQuery(int Id) : IQuery<GetAdministrativeRegionByIdResult>;
    public record GetAdministrativeRegionByIdResult(AdministrativeRegion AdministrativeRegion);
    internal class GetAdministrativeRegionByIdHandler(
        ProvincedbContext dbContext,
        ILogger<GetAdministrativeRegionByIdHandler> logger
        )
        : IQueryHandler<GetAdministrativeRegionByIdQuery, GetAdministrativeRegionByIdResult>
    {
        public async Task<GetAdministrativeRegionByIdResult> Handle(GetAdministrativeRegionByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetAdministrativeRegionByIdHandler.Handle called with {@Query}", query);

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
                throw new AdministrativeRegionNotFoundException();
            }

            return new GetAdministrativeRegionByIdResult(administrativeRegion);
        }
    }
}
