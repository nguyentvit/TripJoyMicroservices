using TravelPlan.Application.Provinces.Queries.GetProvinces;

namespace TravelPlan.API.Endpoints.Province
{
    public record GetProvincesResponse(PaginationResult<ProvinceResponseDto> Provinces);
    public class GetProvinces : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/provinces", async ([AsParameters] PaginationRequest request, [AsParameters] KeySearchProvince keySearch, ISender sender) =>
            {
                var result = await sender.Send(new GetProvincesQuery(request, keySearch));

                var response = result.Adapt<GetProvincesResponse>();

                return Results.Ok(response);
            });
        }
    }
}
