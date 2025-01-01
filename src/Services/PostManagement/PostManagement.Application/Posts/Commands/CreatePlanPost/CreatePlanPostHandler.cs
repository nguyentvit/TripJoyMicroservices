
namespace PostManagement.Application.Posts.Commands.CreatePlanPost
{
    public class CreatePlanPostHandler
        (IApplicationDbContext dbContext) : ICommandHandler<CreatePlanPostCommand, CreatePlanPostResult>
    {
        public async Task<CreatePlanPostResult> Handle(CreatePlanPostCommand command, CancellationToken cancellationToken)
        {
            var planPost = command.ToPlanPost();
            dbContext.PlanPosts.Add(planPost);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePlanPostResult(planPost.Id.Value);
        }
    }
    public static class PlanPostExtension
    {
        public static PlanPost ToPlanPost(this CreatePlanPostCommand command)
        {
            var userId = UserId.Of(command.UserId);

            var planPostRequest = command.PlanPost;

            var postPlanLocations = planPostRequest.PostPlanLocations?.Select(planLocation => PostPlanLocation.Of(
                locationId: LocationId.Of(planLocation.LocationId),
                coordinates: Coordinates.Of(planLocation.Coordinates.Latitude, planLocation.Coordinates.Longitude),
                order: Order.Of(planLocation.Order),
                estimatedStartDate: Date.Of(planLocation.EstimatedStartDate),
                name: LocationName.Of(planLocation.Name),
                address: LocationAddress.Of(planLocation.Address)
                )).ToList();

            var planPost = PlanPost.CreatePlanPost(
                userId: userId,
                content: Content.Of(planPostRequest.Content),
                planId: PlanId.Of(planPostRequest.PlanId),
                startDate: Date.Of(planPostRequest.PlanStartDate),
                endDate: Date.Of(planPostRequest.PlanEndDate),
                budget: Money.Of(planPostRequest.Budget),
                provinceStart: Province.Of(planPostRequest.ProvinceStart.ProvinceId, planPostRequest.ProvinceStart.ProvinceName),
                provinceEnd: Province.Of(planPostRequest.ProvinceEnd.ProvinceId, planPostRequest.ProvinceEnd.ProvinceName),
                vehicle: planPostRequest.Vehicle,
                images: planPostRequest.Images?.Select(FileImg.Of).ToList(),
                postPlanLocations: postPlanLocations
                );

            return planPost;
        }
    }
}
