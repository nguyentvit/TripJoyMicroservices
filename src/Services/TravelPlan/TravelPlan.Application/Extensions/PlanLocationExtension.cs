namespace TravelPlan.Application.Extensions
{
    public static class PlanLocationExtension
    {
        public static async Task<PlanLocationResponseDto> ToPlanLocationResponseDto(this PlanLocation PlanLocation, ILocationGrpcService grpcService, IUserAccessService userService)
        {
            return await FromPlanLocation(PlanLocation, grpcService, userService);
        }
        public static async Task<GetPlanAvailableToJoinByPlanIdDto> ToGetPlanAvailableToJoinByPlanIdDto(this PlanLocation PlanLocation, ILocationGrpcService grpcService)
        {
            return await GetPlanAvailableToJoinByPlanIdDtoFromPlanLocation(PlanLocation, grpcService);
        }
        private static async Task<PlanLocationResponseDto> FromPlanLocation(PlanLocation planLocation, ILocationGrpcService grpcService, IUserAccessService userService)
        {
            List<Guid> userIds = [];
            var location = await grpcService.GetLocationByLocationId(planLocation.LocationId.Value.ToString());
            if (location == null)
                throw new Exception($"Location with id: {planLocation.LocationId.Value} not found.");

            if (planLocation.PayerId != null)
            {
                userIds.Add(planLocation.PayerId.Value);
            }

            foreach (var userSpender in planLocation.PlanLocationUserSpenders)
            {
                userIds.Add(userSpender.UserSpenderId.Value);
            }

            _ = userIds.Distinct();

            var usersInfo = await userService.GetUsersInfoAsync(userIds);

            var userPayer = (planLocation.PayerId == null) ? null : usersInfo.FirstOrDefault(u => u.UserId == planLocation.PayerId.Value);

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
                UserPayer: (planLocation.PayerId == null) ? null : new PlanLocationUserResponse(userPayer!.UserId, userPayer.UserName, userPayer.Avatar),
                Amount: (planLocation.Amount != null) ? planLocation.Amount.Value : null,
                LocationName: location.Name,
                LocationAddress: location.Address,
                Images: planLocation.Images.Select(i => new PlanLocationImageResponse(i.Image.Url)).ToList(),
                UserSpenders: planLocation.PlanLocationUserSpenders.Select(u =>
                {
                    var user = usersInfo.FirstOrDefault(userInfo => userInfo.UserId == u.UserSpenderId.Value);
                    return new PlanLocationUserResponse(user!.UserId, user.UserName, user.Avatar);
                }).ToList()
                );

            return planLocationResponseDto;
        }
        private static async Task<GetPlanAvailableToJoinByPlanIdDto> GetPlanAvailableToJoinByPlanIdDtoFromPlanLocation(PlanLocation planLocation, ILocationGrpcService grpcService)
        {
            var location = await grpcService.GetLocationByLocationId(planLocation.LocationId.Value.ToString());
            if (location == null)
                throw new Exception($"Location with id: {planLocation.LocationId.Value} not found.");

            return new GetPlanAvailableToJoinByPlanIdDto(
                Coordinates: new GetPlanAvailableToJoinByPlanIdDtoCoordinates(planLocation.Coordinates.Longitude, planLocation.Coordinates.Latitude),
                Order: planLocation.Order.Value,
                EstimatedStartDate: planLocation.EstimatedStartDate.Value,
                LocationName: location.Name,
                LocationAddress: location.Address);
        }
    }
}
