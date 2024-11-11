namespace LocationAttraction.Application.LocationCategories.Queries.GetLocationCategories
{
    public class GetLocationCategoriesHandler
        (IApplicationDbContext dbContext)
        : IQueryHandler<GetLocationCategoriesQuery, GetLocationCategoriesResult>
    {
        public async Task<GetLocationCategoriesResult> Handle(GetLocationCategoriesQuery request, CancellationToken cancellationToken)
        {
            var locationCategories = await dbContext.LocationCategories.ToListAsync(cancellationToken);
            var locationCategoriesDto = locationCategories.Select(lc => ToLocationCategoryResponseDto(lc)).ToList();

            return new GetLocationCategoriesResult(locationCategoriesDto);
        }
        private LocationCategoryResponseDto ToLocationCategoryResponseDto(LocationCategory locationCategory)
        {
            return new LocationCategoryResponseDto(
                Id: locationCategory.Id.Value.ToString(),
                Name: locationCategory.Name.Value,
                Description: locationCategory.Description.Value
                );
        }
    }
}
