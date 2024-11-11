namespace LocationAttraction.Application.Locations.Commands.RateLocation
{
    public record RateLocationCommand(LocationRatingDto Rating) : ICommand<RateLocationResult>;
    public record RateLocationResult(bool IsSuccess);
    public class RateLocationCommandValidator : AbstractValidator<RateLocationCommand>
    {
        public RateLocationCommandValidator()
        {
            RuleFor(x => x.Rating)
                .NotNull()
                .WithMessage("Rating data is required");

            RuleFor(x => x.Rating.LocationId)
                .NotEmpty()
                .WithMessage("LocationId is required")
                .Must(BeValidGuid)
                .WithMessage("LocationId must be a valid Guid");

            RuleFor(x => x.Rating.UserId)
                .NotEmpty()
                .WithMessage("UserId is required")
                .Must(BeValidGuid)
                .WithMessage("UserId must be a valid Guid");

            RuleFor(x => x.Rating.Value)
                .InclusiveBetween(0.5, 5.0)
                .WithMessage("Rating value must be between 0.5 and 5.0.");
        }
        private bool BeValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
