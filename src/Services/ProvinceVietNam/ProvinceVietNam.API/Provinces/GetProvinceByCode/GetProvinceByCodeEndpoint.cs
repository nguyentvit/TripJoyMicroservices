namespace ProvinceVietNam.API.Provinces.GetProvinceByCode
{
    public record GetProvinceByCodeResponse(Province Province);
    public class GetProvinceByCodeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/provinces/{code}", async (string code, ISender sender) =>
            {
                var result = await sender.Send(new GetProvinceByCodeQuery(code));

                var response = result.Adapt<GetProvinceByCodeResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProvinceByCode")
            .Produces<GetProvinceByCodeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Province By Code")
            .WithDescription("Get Province By Code");
        }
    }
}
