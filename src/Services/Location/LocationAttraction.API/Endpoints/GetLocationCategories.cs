
using LocationAttraction.Application.LocationCategories.Queries.GetLocationCategories;

namespace LocationAttraction.API.Endpoints
{
    public record GetLocationCategoriesResponse(List<LocationCategoryResponseDto> LocationCategories);
    public class GetLocationCategories : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/locationCategory", async (ISender sender) =>
            {
                var query = new GetLocationCategoriesQuery();

                var result = await sender.Send(query);

                var response = result.Adapt<GetLocationCategoriesResponse>();

                return Results.Ok(response);
            })
            .WithName("GetLocationCategories")
            .Produces<GetLocationCategoriesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Location Categories")
            .WithDescription("Get Location Categories");
        }
    }
}
