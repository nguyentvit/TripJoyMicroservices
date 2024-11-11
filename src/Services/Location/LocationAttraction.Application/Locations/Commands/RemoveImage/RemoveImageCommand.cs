namespace LocationAttraction.Application.Locations.Commands.RemoveImage
{
    public record RemoveImageCommand(string LocationId, string ImageId) : ICommand<RemoveImageResult>;
    public record RemoveImageResult(bool IsSuccess);
    public class RemoveImageCommandValidator : AbstractValidator<RemoveImageCommand>
    {
        public RemoveImageCommandValidator()
        {
            RuleFor(x => x.LocationId)
                .NotEmpty()
                .WithMessage("LocationId is required")
                .Must(BeValidGuid)
                .WithMessage("LocationId must be a valid Guid");

            RuleFor(x => x.ImageId)
                .NotEmpty()
                .WithMessage("ImageId is required")
                .Must(BeValidGuid)
                .WithMessage("ImageId must be a valid Guid");
        }
        private bool BeValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
