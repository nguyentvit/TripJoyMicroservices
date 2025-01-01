namespace TravelPlan.Application.Dtos
{
    public record GetPlansToSharePostDto(Guid Id, string Title, string? Avatar, DateTime StartDate, DateTime EndDate);
    public record GetPlansToSharePostDtoSearchByTitle(string? Title);
}
