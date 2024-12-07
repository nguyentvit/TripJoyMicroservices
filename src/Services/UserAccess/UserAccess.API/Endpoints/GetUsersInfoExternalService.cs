
using UserAccess.Application.Users.Queries.GetUsersInfoExternalService;

namespace UserAccess.API.Endpoints
{
    public record GetUsersInfoExternalServiceRequest(List<Guid> UserIds);
    public record GetUsersInfoExternalServiceResponse(List<UserInfoExternalServiceDto> UsersInfo);
    public class GetUsersInfoExternalService : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/external/users", async (ISender sender, GetUsersInfoExternalServiceRequest request) =>
            {
                var query = new GetUsersInfoExternalServiceQuery(request.UserIds);

                var result = await sender.Send(query);

                var response = result.Adapt<GetUsersInfoExternalServiceResponse>();

                return Results.Ok(response);
            });
        }
    }
}
