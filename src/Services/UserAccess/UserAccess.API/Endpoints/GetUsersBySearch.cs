using UserAccess.Application.Users.Queries.GetUsersBySearch;

namespace UserAccess.API.Endpoints
{
    public record GetUsersBySearchResponse(PaginationResult<UserResponseOtherDto> Users);
    public class GetUsersBySearch : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/search", async ([AsParameters] PaginationRequest request, [AsParameters] KeySearch keySearch, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var myId = httpContext.HttpContext!.GetUserIdFromJwt();

                var result = await sender.Send(new GetUsersBySearchQuery(myId, keySearch, request));

                var response = result.Adapt<GetUsersBySearchResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUsersBySearch")
            .Produces<GetUsersBySearchResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Users By Search")
            .WithDescription("Get Users By Search");
        }
    }
}
