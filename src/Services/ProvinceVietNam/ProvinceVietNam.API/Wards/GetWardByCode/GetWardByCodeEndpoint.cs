namespace ProvinceVietNam.API.Wards.GetWardByCode
{
    public record GetWardByCodeResponse(Ward Ward);
    public class GetWardByCodeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/wards/{code}", async (string code, ISender sender) =>
            {
                var result = await sender.Send(new GetWardByCodeQuery(code));

                var response = result.Adapt<GetWardByCodeResponse>();

                return Results.Ok(response);
            })
            .WithName("GetWardByCode")
            .Produces<GetWardByCodeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Ward By Code")
            .WithDescription("Get Ward By Code");
        }
    }
}
