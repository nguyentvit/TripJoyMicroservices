namespace LocationAttraction.Application.LocationCategories.Queries.GetLocationCategories
{
    public record GetLocationCategoriesQuery() : IQuery<GetLocationCategoriesResult>;
    public record GetLocationCategoriesResult(List<LocationCategoryResponseDto> LocationCategories);
}
