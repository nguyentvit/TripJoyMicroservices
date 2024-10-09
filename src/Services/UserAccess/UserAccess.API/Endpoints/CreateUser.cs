using UserAccess.Application.Users.Commands.CreateUser;

namespace UserAccess.API.Endpoints
{
    public record CreateUserRequest(UserAddDto User);
    public record CreateUserResponse(Guid Id);
    public class CreateUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (CreateUserRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateUserCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateUserResponse>();

                return Results.Created($"/users/{response.Id}", response);
            })
            .WithName("CreateUser")
            .Produces<CreateUserResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create User")
            .WithDescription("Create User");
        }
    }
}
