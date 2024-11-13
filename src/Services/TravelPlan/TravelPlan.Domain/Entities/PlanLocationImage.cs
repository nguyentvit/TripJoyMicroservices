namespace TravelPlan.Domain.Entities
{
    public class PlanLocationImage : Entity<PlanLocationImageId>
    {
        public UserId UserIdUploaded { get; private set; } = default!;
        public Image Image { get; private set; } = default!;
        public Title Title { get; private set; } = default!;
        private PlanLocationImage() { }
        private PlanLocationImage(PlanLocationImageId id, UserId userId, Image image, Title title)
        {
            Id = id;
            UserIdUploaded = userId;
            Image = image;
            Title = title;
        }
        public static PlanLocationImage Of(UserId userId, Image image, Title title)
        {
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(image);
            ArgumentNullException.ThrowIfNull(title);

            return new PlanLocationImage(
                PlanLocationImageId.Of(Guid.NewGuid()),
                userId,
                image,
                title
                );
        }
    }
}
