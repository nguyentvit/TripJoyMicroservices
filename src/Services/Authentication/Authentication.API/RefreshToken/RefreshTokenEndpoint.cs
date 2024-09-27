namespace Authentication.API.RefreshToken
{
    public record RefreshTokenRequest(string RefreshToken);
    public record RefreshTokenResponse(UserLogin UserLogin);
    public class RefreshTokenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/refresh-token", async (RefreshTokenRequest request, ISender sender) =>
            {
                var command = request.Adapt<RefreshTokenCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<RefreshTokenResponse>();

                return Results.Ok(response);
            });
        }
    }
}
