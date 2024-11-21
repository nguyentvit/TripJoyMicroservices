namespace TravelPlan.Application.Provinces.Queries.GetProvinces
{
    public class GetProvincesHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetProvincesQuery, GetProvincesResult>
    {
        public async Task<GetProvincesResult> Handle(GetProvincesQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Provinces.CountAsync(cancellationToken);
            var provinces = await dbContext.Provinces
                .OrderBy(p => p.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(p => new ProvinceResponseDto(p.Id.Value, p.Name.Value))
                .ToListAsync(cancellationToken);

            return new GetProvincesResult(new PaginationResult<ProvinceResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                provinces
                ));
        }
    }
}
