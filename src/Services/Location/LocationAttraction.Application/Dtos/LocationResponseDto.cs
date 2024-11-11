namespace LocationAttraction.Application.Dtos
{
    public record LocationResponseDto(
        string Name,
        string Address,
        LocationCoordinatesResponseDto Coordinates,
        LocationAverageRatingResponseDto AverageRating,
        LocationCategoryResponseDto LocationCategory,
        List<LocationImageResponseDto> Images
        );
    public record LocationCoordinatesResponseDto(double Longitude, double Latitude);
    public record LocationAverageRatingResponseDto(double Value, int NumRatings);
    public record LocationImageResponseDto(string Url, string ImageId);
    public record LocationRatingResponseDto(string UserId, double Value);
}
