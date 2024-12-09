namespace Chat.Application.ChatRooms.Commands.CreatePlanRoom
{
    public record CreatePlanRoomCommand(Guid PlanId, Guid UserId, string ChatRoomName) : ICommand<CreatePlanRoomResult>;
    public record CreatePlanRoomResult(CreatePlanRoomDto Room);
    public class CreatePlanRoomCommandValidator : AbstractValidator<CreatePlanRoomCommand>
    {
        public CreatePlanRoomCommandValidator()
        {
            RuleFor(x => x.PlanId)
                .NotEmpty()
                .WithMessage("PlanId is required.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");
            RuleFor(x => x.ChatRoomName)
                .NotEmpty().WithMessage("ChatRoomName is required.")
                .MaximumLength(100).WithMessage("ChatRoomName cannot exceed 100 characters.");
        }
    }
}
