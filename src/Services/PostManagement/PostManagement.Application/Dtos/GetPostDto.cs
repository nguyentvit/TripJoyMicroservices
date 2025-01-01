namespace PostManagement.Application.Dtos
{
    public record GetPostDto(
        Guid PostId,
        GetPostDtoUserPosted UserPosted, 
        string Content, 
        int LikeCount, 
        PostType PostType,
        GetPostDtoPlanPost? PlanPost,
        DateTime CreatedAt,
        int CommentCount,
        Emotion? EmotionByMe,
        List<GetPostDtoPostImage> PostImages,
        List<GetPostDtoPostReactionDistinct> PostReactions);
    public record GetPostDtoUserPosted(Guid UserId, string UserName, string? Avatar);
    public record GetPostDtoPostImage(string Url);
    public record GetPostDtoPostReactionDistinct(Emotion Emotion);
    public record GetPostDtoPlanPost(
        Guid PlanId, 
        DateTime PlanStartDate, 
        DateTime PlanEndDate, 
        decimal Budget, 
        GetPostDtoPlanPostProvince ProvinceStart, 
        GetPostDtoPlanPostProvince ProvinceEnd, 
        PlanVehicle Vehicle,
        List<GetPostDtoPlanPostPostPlanLocation> PostPlanLocations
        );
    public record GetPostDtoPlanPostProvince(Guid ProvinceId, string ProvinceName);
    public record GetPostDtoPlanPostPostPlanLocation(Guid LocationId, GetPostDtoPlanPostPostPlanLocationCoordinates Coordinates, int Order, DateTime EstimatedStartDate, string Name, string Address);
    public record GetPostDtoPlanPostPostPlanLocationCoordinates(double Latitude, double Longitude);
}
