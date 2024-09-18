
namespace ProvinceVietNam.API.AdministrativeRegions.GetAdministrativeRegionById
{
    public record GetAdministrativeRegionByIdResponse(AdministrativeRegion AdministrativeRegion);
    public class GetAdministrativeRegionByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/administrativeregions/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetAdministrativeRegionByIdQuery(id));

                var response = result.Adapt<GetAdministrativeRegionByIdResponse>();

                return Results.Ok(result);
            })
            .WithName("GetAdministrativeRegionById")
            .Produces<GetAdministrativeRegionByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Administrative Region By Id")
            .WithDescription("Get Administrative Region By Id");
        }
    }
}
