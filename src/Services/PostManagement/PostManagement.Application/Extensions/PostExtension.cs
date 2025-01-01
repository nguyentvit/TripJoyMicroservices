using BuildingBlocks.Dtos;

namespace PostManagement.Application.Extensions
{
    public static class PostExtension
    {
        public static GetPostDto ToGetPostDtoFromPost(this Post post, UserId userId, List<UserInfoExternalServiceDto> UsersInfo)
        {
            var emotion = post.PostReactions.FirstOrDefault(reaction => reaction.UserId == userId);
            var userPosted = UsersInfo.FirstOrDefault(u => u.UserId == post.UserId.Value);
            var postDto = new GetPostDto(
                PostId: post.Id.Value,
                UserPosted: new GetPostDtoUserPosted(userPosted!.UserId, userPosted.UserName, userPosted.Avatar),
                Content: post.Content.Value,
                LikeCount: post.LikeCount.Value,
                PostType: post.PostType,
                PlanPost: null,
                CreatedAt: post.CreatedAt!.Value,
                CommentCount: post.CommentIds.Count,
                EmotionByMe: emotion?.Emotion,
                PostImages: post.PostImages.Select(postImage => new GetPostDtoPostImage(postImage.Image.Url)).ToList(),
                PostReactions: post.PostReactions.Select(pr => new GetPostDtoPostReactionDistinct(pr.Emotion)).Distinct().ToList()
                );

            return postDto;
        }
        public static GetPostDto ToGetPostDtoFromPlanPost(this PlanPost post, UserId userId, List<UserInfoExternalServiceDto> UsersInfo)
        {
            var emotion = post.PostReactions.FirstOrDefault(reaction => reaction.UserId == userId);

            var planPostDto = new GetPostDtoPlanPost(
                PlanId: post.PlanId.Value,
                PlanStartDate: post.PlanStartDate.Value,
                PlanEndDate: post.PlanEndDate.Value,
                Budget: post.Budget.Value,
                ProvinceStart: new GetPostDtoPlanPostProvince(post.ProvinceStart.ProvinceId, post.ProvinceStart.ProvinceName),
                ProvinceEnd: new GetPostDtoPlanPostProvince(post.ProvinceEnd.ProvinceId, post.ProvinceEnd.ProvinceName),
                Vehicle: post.Vehicle,
                PostPlanLocations: post.PostPlanLocations.Select(planLocation => new GetPostDtoPlanPostPostPlanLocation(
                    LocationId: planLocation.LocationId.Value,
                    Coordinates: new GetPostDtoPlanPostPostPlanLocationCoordinates(planLocation.Coordinates.Latitude, planLocation.Coordinates.Longitude),
                    Order: planLocation.Order.Value,
                    EstimatedStartDate: planLocation.EstimatedStartDate.Value,
                    Name: planLocation.Name.Value,
                    Address: planLocation.Address.Value
                    )).ToList()
                );

            var userPosted = UsersInfo.FirstOrDefault(u => u.UserId == post.UserId.Value);
            var postDto = new GetPostDto(
                PostId: post.Id.Value,
                UserPosted: new GetPostDtoUserPosted(userPosted!.UserId, userPosted.UserName, userPosted.Avatar),
                Content: post.Content.Value,
                LikeCount: post.LikeCount.Value,
                PostType: post.PostType,
                PlanPost: planPostDto,
                CreatedAt: post.CreatedAt!.Value,
                CommentCount: post.CommentIds.Count,
                EmotionByMe: emotion?.Emotion,
                PostImages: post.PostImages.Select(postImage => new GetPostDtoPostImage(postImage.Image.Url)).ToList(),
                PostReactions: post.PostReactions.Select(pr => new GetPostDtoPostReactionDistinct(pr.Emotion)).Distinct().ToList()
                );

            return postDto;
        }
    }
}
