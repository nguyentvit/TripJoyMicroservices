namespace Authentication.API.Login
{
    public record LoginRequest(string Email, string Password);
    public record LoginResponse(UserLogin UserLogin);
    public class LoginEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/login", async (LoginRequest request, ISender sender) =>
            {
                var command = request.Adapt<LoginCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<LoginResponse>();

                return Results.Ok(response);
            })
            .WithName("CreateProduct")
            .Produces<LoginResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
