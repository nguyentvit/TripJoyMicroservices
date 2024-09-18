namespace ProvinceVietNam.API.Wards.GetWards
{
    public record GetWardsResponse(IEnumerable<Ward> Wards);
    public class GetWardsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/wards", async (ISender sender) =>
            {
                var result = await sender.Send(new GetWardsQuery());

                var response = result.Adapt<GetWardsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetWards")
            .Produces<GetWardsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Wards")
            .WithDescription("Get Wards");
        }
    }
}
