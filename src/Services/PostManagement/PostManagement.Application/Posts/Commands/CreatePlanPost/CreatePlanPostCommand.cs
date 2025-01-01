namespace PostManagement.Application.Posts.Commands.CreatePlanPost
{
    public record CreatePlanPostCommand(Guid UserId, CreatePlanPostDto PlanPost) : ICommand<CreatePlanPostResult>;
    public record CreatePlanPostResult(Guid PostId);
    public class CreatePlanPostCommandValidator : AbstractValidator<CreatePlanPostCommand>
    {
        public CreatePlanPostCommandValidator()
        {

        }
    }
}
