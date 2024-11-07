using UserAccess.Application.Users.Queries.GetInfo;

namespace UserAccess.API.Endpoints
{
    public record GetInfoResponse(UserInfoDto User);
    public class GetInfo : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/info", async (ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                var result = await sender.Send(new GetInfoQuery(userId));

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
