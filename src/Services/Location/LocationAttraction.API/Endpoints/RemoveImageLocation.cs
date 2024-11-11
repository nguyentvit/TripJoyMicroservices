using LocationAttraction.Application.Locations.Commands.RemoveImage;

namespace LocationAttraction.API.Endpoints
{
    public record RemoveImageLocationRequest(string LocationId, string ImageId);
    public record RemoveImageLocationResponse(bool IsSuccess);
    public class RemoveImageLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/location/image", async ([AsParameters] RemoveImageLocationRequest request, ISender sender) =>
            {
                var command = request.Adapt<RemoveImageCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<RemoveImageLocationResponse>();

                return Results.Ok(response);
            })
            .WithName("RemoveImageLocation")
            .Produces<RemoveImageLocationResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Remove Image Location")
            .WithDescription("Remove Image Location");
        }
    }
}
