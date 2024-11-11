using LocationAttraction.Application.Locations.Commands.CreateLocation;

namespace LocationAttraction.API.Endpoints
{
    public record CreateLocationRequest(LocationAddDto Location);
    public record CreateLocationResponse(string LocationId);
    public class CreateLocation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/location", async (CreateLocationRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateLocationCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateLocationResponse>();

                return Results.Created($"/location/{response.LocationId}", response);
            })
            .WithName("CreateLocation")
            .Produces<CreateLocationResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Location")
            .WithDescription("Create Location");
        }
    }
}
