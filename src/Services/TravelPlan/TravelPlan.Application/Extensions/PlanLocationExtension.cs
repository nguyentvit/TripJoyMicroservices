﻿namespace TravelPlan.Application.Extensions
{
    public static class PlanLocationExtension
    {
        public static PlanLocationResponseDto ToPlanLocationResponseDto(this PlanLocation PlanLocation)
        {
            return FromPlanLocation(PlanLocation);
        }
        private static PlanLocationResponseDto FromPlanLocation(PlanLocation planLocation)
        {
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
                Images: planLocation.Images.Select(i => new PlanLocationImageResponse(i.Image.Url)).ToList(),
                UserSpenders: planLocation.PlanLocationUserSpenders.Select(u => new PlanLocationUserSpenderResponse(u.UserSpenderId.Value)).ToList()
                );

            return planLocationResponseDto;
        }
    }
}
