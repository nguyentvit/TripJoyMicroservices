namespace Authentication.API.Logout
{
    public record LogoutRequest(string RefreshToken);
    public record LogoutResponse(string Message);
    public class LogoutEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("logout", async (LogoutRequest request, ISender sender) =>
            {
                var command = request.Adapt<LogoutCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<LogoutResponse>();

                return Results.Ok(response);
            })
                .RequireAuthorization();
        }
        
    }
}
