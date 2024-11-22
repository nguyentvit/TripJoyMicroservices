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
            var keySearchName = query.KeySearch.Name;

            var provincesQuery = await dbContext.Provinces.ToListAsync(cancellationToken);

            if (!string.IsNullOrEmpty(keySearchName))
            {
                provincesQuery = provincesQuery.Where(p => p.Name.Value.ToLower().StartsWith(keySearchName.ToLower())).ToList();
            }

            var totalCount = provincesQuery.Count;

            var provinces = provincesQuery
                .OrderBy(p => p.Name.Value)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(province => new ProvinceResponseDto(province.Id.Value, province.Name.Value))
                .ToList();


            return new GetProvincesResult(new PaginationResult<ProvinceResponseDto>(
                pageIndex,
                pageSize,
                totalCount,
                provinces
                ));
        }
    }
}
