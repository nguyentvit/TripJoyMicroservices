namespace TravelPlan.Application.Grpc
{
    public interface ILocationGrpcService
    {
        Task<GrpcLocationGetDto> GetLocationByCoordinates(double Latitude, double Longitude, string Name, string Address);
        Task<GrpcLocationGetDto> GetLocationByLocationId(string LocationId);
    }
}
