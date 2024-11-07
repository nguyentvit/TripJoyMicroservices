using UserAccess.Application.Users.Commands.UpdateUser;
namespace UserAccess.API.Endpoints
{
    public record UpdateUserRequest(
        string UserName, 
        string PhoneNumber, 
        string? DateOfBirth, 
        ImageDto? Avatar, 
        AddressDto? Address, 
        UserGender? Gender
        );
    public record UpdateUserResponse(bool IsSuccess);
    public class UpdateUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/users", async (UpdateUserRequest request, ISender sender, IHttpContextAccessor httpContext) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt()!;

                UserUpdateDto userUpdateDto = new(
                    UserId: userId,
                    UserName: request.UserName,
                    PhoneNumber: request.PhoneNumber,
                    DateOfBirth: request.DateOfBirth,
                    Avatar: request.Avatar,
                    Address: request.Address,
                    Gender: request.Gender
                    );

                var userUpdateDtoRequest = new
                {
                    User = userUpdateDto
                };

                var command = userUpdateDtoRequest.Adapt<UpdateUserCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateUserResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateUser")
            .Produces<UpdateUserResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update User")
            .WithDescription("Update User");
        }
    }
}
