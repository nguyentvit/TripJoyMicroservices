namespace ProvinceVietNam.API.Districts.GetDistricts
{
    public record GetDistrictsResponse(IEnumerable<District> Districts);
    public class GetDistrictsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/districts", async (ISender sender) =>
            {
                var result = await sender.Send(new GetDistrictsQuery());

                var response = result.Adapt<GetDistrictsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDistricts")
            .Produces<GetDistrictsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Districts")
            .WithDescription("Get Districts");
        }
    }
}
