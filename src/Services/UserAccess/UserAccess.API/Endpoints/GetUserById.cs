using UserAccess.Application.Users.Queries.GetUserById;

namespace UserAccess.API.Endpoints
{
    public record GetUserByIdResponse(UserResponseOtherDto User);
    public class GetUserById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/{userId}", async (Guid userId, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var myId = httpContext.HttpContext!.GetUserIdFromJwt();

                var result = await sender.Send(new GetUserByIdQuery(myId, userId));

                var response = result.Adapt<GetUserByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUserById")
            .Produces<GetUserByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get User By Id")
            .WithDescription("Get User By Id");
        }
    }
}
