using TravelPlan.Application.Provinces.Queries.GetProvinces;

namespace TravelPlan.API.Endpoints.Plan
{
    public record GetProvincesResponse(PaginationResult<ProvinceResponseDto> Provinces);
    public class GetProvinces : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/provinces", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetProvincesQuery(request));

                var response = result.Adapt<GetProvincesResponse>();

                return Results.Ok(response);
            });
        }
    }
}
