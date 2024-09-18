namespace ProvinceVietNam.API.AdministrativeRegions.GetAdministrativeRegions
{
    public record GetAdministrativeRegionsReponse(IEnumerable<AdministrativeRegion> AdministrativeRegions);
    public class GetAdministrativeRegionsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/administrativeregions", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAdministrativeRegionsQuery());

                var response = result.Adapt<GetAdministrativeRegionsReponse>();

                return Results.Ok(response);
            })
            .WithName("GetAdministrativeRegions")
            .Produces<GetAdministrativeRegionsReponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Administrative Regions")
            .WithDescription("Get Administrative Regions");
        }
    }
}
