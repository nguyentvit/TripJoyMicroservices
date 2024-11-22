namespace TravelPlan.Application.Provinces.Queries.GetProvinces
{
    public record GetProvincesQuery(PaginationRequest PaginationRequest, KeySearchProvince KeySearch) : IQuery<GetProvincesResult>;
    public record GetProvincesResult(PaginationResult<ProvinceResponseDto> Provinces);
}
