using LocationAttraction.Application.Locations.Commands.AddImage;

namespace LocationAttraction.API.Endpoints
{
    public record AddImageRequest(LocationAddImageDto Image);
    public record AddImageResponse(bool IsSuccess);
    public class AddImage : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/location/image", async (AddImageRequest request, ISender sender) =>
            {
                var command = request.Adapt<AddImageCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<AddImageResponse>();

                return Results.Ok(response);
            })
            .WithName("AddImageLocation")
            .Produces<AddImageResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Image Location")
            .WithDescription("Add Image Location");
        }
    }
}
