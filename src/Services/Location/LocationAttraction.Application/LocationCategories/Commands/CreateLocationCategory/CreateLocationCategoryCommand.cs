namespace LocationAttraction.Application.LocationCategories.Commands.CreateLocationCategory
{
    public record CreateLocationCategoryCommand(LocationCategoryAddDto LocationCategory) : ICommand<CreateLocationCategoryResult>;
    public record CreateLocationCategoryResult(string LocationCategoryId);
    public class CreateLocationCategoryCommandValidator : AbstractValidator<CreateLocationCategoryCommand>
    {
        public CreateLocationCategoryCommandValidator()
        {
            RuleFor(x => x.LocationCategory)
                .NotNull()
                .WithMessage("LocationCategory cannot be null.");

            RuleFor(x => x.LocationCategory.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MaximumLength(100)
                .WithMessage("Category name cannot exceed 100 characters");

            RuleFor(x => x.LocationCategory.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description cannot exceed 500 characters");
        }
    }
}
