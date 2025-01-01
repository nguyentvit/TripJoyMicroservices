namespace PostManagement.Application.Dtos
{
    public class CreatePlanPostDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid PlanId { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public decimal Budget { get; set; }
        public CreatePlanPostDtoProvince ProvinceStart { get; set; } = null!;
        public CreatePlanPostDtoProvince ProvinceEnd { get; set; } = null!;
        public PlanVehicle Vehicle { get; set; }
        public List<IFormFile>? Images { get; set; } = null;
        public List<CreatePlanPostDtoPostPlanLocation>? PostPlanLocations { get; set; } = null!;
    }

    public record CreatePlanPostDtoProvince(Guid ProvinceId, string ProvinceName);
    public record CreatePlanPostDtoPostPlanLocation(Guid LocationId, CreatePlanPostDtoPostPlanLocationCoordinates Coordinates, int Order, DateTime EstimatedStartDate, string Name, string Address);
    public record CreatePlanPostDtoPostPlanLocationCoordinates(double Latitude, double Longitude);
}
