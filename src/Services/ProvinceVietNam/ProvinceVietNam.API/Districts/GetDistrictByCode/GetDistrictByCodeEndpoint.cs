namespace ProvinceVietNam.API.Districts.GetDistrictByCode
{
    public record GetDistrictByCodeResponse(District District);
    public class GetDistrictByCodeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/districts/{code}", async (string code, ISender sender) =>
            {
                var result = await sender.Send(new GetDistrictByCodeQuery(code));

                var response = result.Adapt<GetDistrictByCodeResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDistrictByCode")
            .Produces<GetDistrictByCodeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get District By Code")
            .WithDescription("Get District By Code");
        }
    }
}
