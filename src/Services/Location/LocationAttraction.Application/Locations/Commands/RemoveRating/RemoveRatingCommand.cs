namespace LocationAttraction.Application.Locations.Commands.RemoveRating
{
    public record RemoveRatingCommand(string LocationId, string UserId) : ICommand<RemoveRatingResult>;
    public record RemoveRatingResult(bool IsSuccess);
    public class RemoveRatingCommandValidator : AbstractValidator<RemoveRatingCommand>
    {
        public RemoveRatingCommandValidator()
        {
            RuleFor(x => x.LocationId)
                .NotEmpty()
                .WithMessage("LocationId is required")
                .Must(BeValidGuid)
                .WithMessage("LocationId must be a valid Guid");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required")
                .Must(BeValidGuid)
                .WithMessage("UserId must be a valid Guid");
        }
        private bool BeValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
