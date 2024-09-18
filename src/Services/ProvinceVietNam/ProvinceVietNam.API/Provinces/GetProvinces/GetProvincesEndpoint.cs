namespace ProvinceVietNam.API.Provinces.GetProvinces
{
    public record GetProvincesResponse(IEnumerable<Province> Provinces);
    public class GetProvincesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/provinces", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProvincesQuery());

                var response = result.Adapt<GetProvincesResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProvinces")
            .Produces<GetProvincesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Provinces")
            .WithDescription("Get Provinces");

        }
    }
}
