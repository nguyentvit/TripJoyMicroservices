using LocationAttraction.Application.LocationCategories.Commands.CreateLocationCategory;

namespace LocationAttraction.API.Endpoints
{
    public record CreateLocationCategoryRequest(LocationCategoryAddDto LocationCategory);
    public record CreateLocationCategoryResponse(string LocationCategoryId);
    public class CreateLocationCategory : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/locationCategory", async (CreateLocationCategoryRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateLocationCategoryCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateLocationCategoryResponse>();

                return Results.Created($"/locationCategory/{response.LocationCategoryId}", response);
            })
            .WithName("CreateLocationCategory")
            .Produces<CreateLocationCategoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Location Category")
            .WithDescription("Create Location Category");
        }
    }
}
