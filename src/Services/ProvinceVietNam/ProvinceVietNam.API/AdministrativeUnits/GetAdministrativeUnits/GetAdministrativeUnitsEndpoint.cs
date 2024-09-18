namespace ProvinceVietNam.API.AdministrativeUnits.GetAdministrativeUnits
{
    public record GetAdministrativeUnitsReponse(IEnumerable<AdministrativeUnit> AdministrativeUnits);
    public class GetAdministrativeUnitsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/administrativeunits", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAdministrativeUnitsQuery());

                var response = result.Adapt<GetAdministrativeUnitsReponse>();

                return Results.Ok(response);
            })
            .WithName("GetAdministrativeUnits")
            .Produces<GetAdministrativeUnitsReponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get AdministrativeUnits")
            .WithDescription("Get AdministrativeUnits");
        }
    }
}
