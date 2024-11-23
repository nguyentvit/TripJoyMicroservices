using LocationAttraction.Grpc;
using TravelPlan.Application.Dtos;
using TravelPlan.Application.Grpc;

namespace TravelPlan.Infrastructure.Grpc
{
    public class LocationGrpcService
        (LocationAttractionProtoService.LocationAttractionProtoServiceClient locationProto)
         : ILocationGrpcService
    {
        public async Task<GrpcLocationGetDto> GetLocationByCoordinates(double Latitude, double Longitude, string Name, string Address)
        {
            try
            {
                var locationGrpc = await locationProto.GetLocationByCoordinatesAsync(new GetLocationByCoordinatesRequest { Latitude = Latitude, Longitude = Longitude });

                var location = locationGrpc.Location;
                
                var locationDto = new GrpcLocationGetDto(
                    LocationId: Guid.Parse(location.Id),
                    Name: location.Name,
                    Latitude: location.Coordinates.Latitude,
                    Longitude: location.Coordinates.Longitude,
                    AverageRating: new GrpcLocationAverageRatingDto(location.AverageRating.Value, location.AverageRating.NumRatings),
                    LocationCategory: new GrpcLocationLocationCategoryDto(Guid.Parse(location.LocationCategory.Id), location.LocationCategory.Name, location.LocationCategory.Description),
                    Address: location.Address
                    );
                return locationDto;

            }
            catch (Exception ex)
            {
                var location = await locationProto.CreateLocationAsync(new CreateLocationRequest
                {
                    Address = Address,
                    Latitude = Latitude,
                    LocationCategoryId = "662b471a-1b58-48d7-a2ea-d271bec1eb16",
                    Longitude = Longitude,
                    Name = Name
                });

                var locationDto = new GrpcLocationGetDto(
                    LocationId: Guid.Parse(location.LocationId),
                    Name: Name,
                    Latitude: Latitude,
                    Longitude: Longitude,
                    AverageRating: new GrpcLocationAverageRatingDto(0, 0),
                    LocationCategory: new GrpcLocationLocationCategoryDto(Guid.Parse("662b471a-1b58-48d7-a2ea-d271bec1eb16"), "123", "123"),
                    Address: Address
                    );

                return locationDto;
            }
        }

        public async Task<GrpcLocationGetDto> GetLocationByLocationId(string LocationId)
        {
            var locationGrpc = await locationProto.GetLocationByIdAsync(new GetLocationByIdRequest { LocationId = LocationId });
            var location = locationGrpc.Location;
            var locationDto = new GrpcLocationGetDto(
                    LocationId: Guid.Parse(location.Id),
                    Name: location.Name,
                    Latitude: location.Coordinates.Latitude,
                    Longitude: location.Coordinates.Longitude,
                    AverageRating: new GrpcLocationAverageRatingDto(location.AverageRating.Value, location.AverageRating.NumRatings),
                    LocationCategory: new GrpcLocationLocationCategoryDto(Guid.Parse(location.LocationCategory.Id), location.LocationCategory.Name, location.LocationCategory.Description),
                    Address: location.Address
                    );
            return locationDto;

        }
    }
}
