namespace ProvinceVietNam.API.AdministrativeUnits.GetAdministrativeUnitById
{
    public record GetAdministrativeUnitByIdResponse(AdministrativeUnit AdministrativeUnit);
    public class GetAdministrativeUnitByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/administrativeunits/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetAdministrativeUnitByIdQuery(id));

                var response = result.Adapt<GetAdministrativeUnitByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetAdministrativeUnitById")
            .Produces<GetAdministrativeUnitByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Administrative Unit By Id")
            .WithDescription("Get Administrative Unit By Id");
        }
    }
}
