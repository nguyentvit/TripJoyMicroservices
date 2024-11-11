namespace LocationAttraction.Application.LocationCategories.Commands.CreateLocationCategory
{
    public class CreateLocationCategoryHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<CreateLocationCategoryCommand, CreateLocationCategoryResult>
    {
        public async Task<CreateLocationCategoryResult> Handle(CreateLocationCategoryCommand command, CancellationToken cancellationToken)
        {
            var locationCategory = CreateNewLocationCategory(command.LocationCategory);

            dbContext.LocationCategories.Add(locationCategory);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateLocationCategoryResult(locationCategory.Id.Value.ToString());
        }
        private LocationCategory CreateNewLocationCategory(LocationCategoryAddDto locationCategoryDto)
        {
            var newLocationCategory = LocationCategory.Of(
                id: LocationCategoryId.Of(Guid.NewGuid()),
                name: Name.Of(locationCategoryDto.Name),
                description: Description.Of(locationCategoryDto.Description)
                );
            return newLocationCategory;
        }
    }
}
