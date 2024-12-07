using UserAccess.Application.Users.Queries.GetUsersBySearchExternalService;

namespace UserAccess.API.Endpoints
{
    public record GetUsersBySearchExternalServiceResponse(PaginationResult<UserInfoExternalServiceDto> Users);
    public class GetUsersBySearchExternalService : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/external/users/search", async ([AsParameters] PaginationRequest request, ISender sender, [AsParameters] KeySearch keySearch) =>
            {
                var result = await sender.Send(new GetUsersBySearchExternalServiceQuery(request, keySearch));

                var response = result.Adapt<GetUsersBySearchExternalServiceResponse>();

                return Results.Ok(response);
            });
        }
    }
}
