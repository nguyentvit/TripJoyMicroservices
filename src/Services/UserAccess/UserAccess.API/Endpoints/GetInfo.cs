using UserAccess.Application.Users.Queries.GetInfo;

namespace UserAccess.API.Endpoints
{
    public record GetInfoResponse(UserDto User);
    public class GetInfo : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users", async (ISender sender, IHttpContextAccessor httpContext) =>
            {
                var accountId = httpContext.HttpContext?.GetAccountIdFromJwt()!;

                var result = await sender.Send(new GetInfoQuery(accountId));

                var response = result.Adapt<GetInfoResponse>();

                return Results.Ok(response);
            })
            .WithName("GetInfo")
            .Produces<GetInfoResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Info")
            .WithDescription("Get Info");
        }
    }
}
