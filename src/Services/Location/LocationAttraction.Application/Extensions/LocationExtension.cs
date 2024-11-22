namespace LocationAttraction.Application.Extensions
{
    public static class LocationExtension
    {
        public static async Task<LocationResponseDto> ToLocationResponseDto(this Location location, IApplicationDbContext dbContext)
        {
            return await LocationResponseDtoFromLocation(location, dbContext);
        }
        public static List<LocationRatingResponseDto> ToLocationRatingResponseDto(
            this Location location, int PageIndex, int PageSize)
        {
            var ratings = location.Ratings
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new LocationRatingResponseDto(r.UserId.Value.ToString(), r.Value))
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToList();

            return ratings;
        }
        public static List<LocationImageResponseDto> ToLocationImageResponseDto(this Location location, int PageIndex, int PageSize)
        {
            var images = location.Images
                .OrderByDescending(i => i.CreatedAt)
                .Select(i => new LocationImageResponseDto(i.Url, i.Id.Value.ToString()))
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToList();

            return images;
        }
        private async static Task<LocationResponseDto> LocationResponseDtoFromLocation(Location location, IApplicationDbContext dbContext)
        {
            var locationCategoryId = location.LocationCategoryId;
            var locationCategory = await dbContext.LocationCategories.FindAsync([locationCategoryId]);
            if (locationCategory == null)
                throw new LocationCategoryNotFoundException(locationCategoryId.Value);

            var locationResponseDto = new LocationResponseDto(
                Id: location.Id.Value.ToString(),
                Name: location.Name.Value,
                Address: (location.Address == null) ? "" : location.Address.Value,
                Coordinates: new LocationCoordinatesResponseDto(location.Coordinates.Longitude, location.Coordinates.Latitude),
                AverageRating: new LocationAverageRatingResponseDto(location.AverageRating.Value, location.AverageRating.NumRatings),
                LocationCategory: new LocationCategoryResponseDto(locationCategory.Id.Value.ToString(), locationCategory.Name.Value, locationCategory.Description.Value),
                Images: location.Images.Select(i => new LocationImageResponseDto(i.Url, i.Id.Value.ToString())).ToList()
                );

            return locationResponseDto;

        }
    }
}
