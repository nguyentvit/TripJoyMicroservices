namespace TravelPlan.Application.Dtos
{
    public record GrpcLocationGetDto(
        Guid LocationId,
        string Name,
        double Latitude,
        double Longitude,
        GrpcLocationAverageRatingDto AverageRating,
        GrpcLocationLocationCategoryDto LocationCategory
        );
    public record GrpcLocationAverageRatingDto(
        double Value,
        int NumRatings
        );

    public record GrpcLocationLocationCategoryDto(
        Guid LocationCategoryId,
        string Name,
        string Description
        );
}
