namespace LocationAttraction.Application.Locations.Commands.AddImage
{
    public record AddImageCommand(LocationAddImageDto Image) : ICommand<AddImageResult>;
    public record AddImageResult(bool IsSuccess);
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(x => x.Image)
                .NotNull()
                .WithMessage("Image data is required");

            RuleFor(x => x.Image.LocationId)
                .NotEmpty()
                .WithMessage("LocationId is required")
                .Must(BeValidGuid)
                .WithMessage("LocationId must be a valid Guid");

            RuleFor(x => x.Image.Url)
                .NotEmpty()
                .WithMessage("Url is not empty");
        }
        private bool BeValidGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
