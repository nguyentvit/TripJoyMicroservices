namespace LocationAttraction.Application.Locations.Commands.CreateLocation
{
    public record CreateLocationCommand(LocationAddDto Location) : ICommand<CreateLocationResult>;
    public record CreateLocationResult(string LocationId);
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(x => x.Location)
                .NotNull()
                .WithMessage("Location data is required.");

            RuleFor(x => x.Location.Name)
                .NotNull()
                .WithMessage("Location name is required.")
                .MaximumLength(100)
                .WithMessage("Location name must not exceed 100 characters.");

            RuleFor(x => x.Location.Address)
                .MaximumLength(200)
                .WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.Location.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("Latitude must be between -90 and 90 degrees.");

            RuleFor(x => x.Location.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Longitude must be between -180 and 180 degrees.");

            RuleFor(x => x.Location.LocationCategoryId)
                .NotEmpty()
                .WithMessage("Location category ID is required.")
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("Location category ID must be a valid GUID.");
        }
    }
}
