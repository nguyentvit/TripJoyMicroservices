namespace TravelPlan.Application.Extensions
{
    public static class PlanLocationExtension
    {
        public static async Task<PlanLocationResponseDto> ToPlanLocationResponseDto(this PlanLocation PlanLocation, ILocationGrpcService grpcService)
        {
            return await FromPlanLocation(PlanLocation, grpcService);
        }
        private static async Task<PlanLocationResponseDto> FromPlanLocation(PlanLocation planLocation, ILocationGrpcService grpcService)
        {
            var location = await grpcService.GetLocationByLocationId(planLocation.LocationId.Value.ToString());
            if (location == null)
                throw new Exception($"Location with id: {planLocation.LocationId.Value} not found.");

            var planLocationResponseDto = new PlanLocationResponseDto(
                PlanLocationId: planLocation.Id.Value,
                PlanId: planLocation.PlanId.Value,
                LocationId: planLocation.LocationId.Value,
                Longitude: planLocation.Coordinates.Longitude,
                Latitude: planLocation.Coordinates.Latitude,
                Order: planLocation.Order.Value,
                Note: planLocation.Note.Value,
                EstimatedStartDate: planLocation.EstimatedStartDate.Value,
                CompletionDate: (planLocation.CompletionDate != null) ? planLocation.CompletionDate.Value : null,
                Status: planLocation.Status,
                PayerId: (planLocation.PayerId != null) ? planLocation.PayerId.Value : null,
                Amount: (planLocation.Amount != null) ? planLocation.Amount.Value : null,
                LocationName: location.Name,
                LocationAddress: location.Address,
                Images: planLocation.Images.Select(i => new PlanLocationImageResponse(i.Image.Url)).ToList(),
                UserSpenders: planLocation.PlanLocationUserSpenders.Select(u => new PlanLocationUserSpenderResponse(u.UserSpenderId.Value)).ToList()
                );

            return planLocationResponseDto;
        }
    }
}
