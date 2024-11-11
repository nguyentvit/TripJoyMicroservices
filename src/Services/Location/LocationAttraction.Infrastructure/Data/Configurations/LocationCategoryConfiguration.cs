using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationAttraction.Infrastructure.Data.Configurations
{
    public class LocationCategoryConfiguration : IEntityTypeConfiguration<LocationCategory>
    {
        public void Configure(EntityTypeBuilder<LocationCategory> builder)
        {
            ConfigureLocationCategoryTable(builder);
            ConfigureLocationRelation(builder);
        }
        public void ConfigureLocationCategoryTable(EntityTypeBuilder<LocationCategory> builder)
        {
            builder.HasKey(lc => lc.Id);

            builder.Property(lc => lc.Id)
                .HasConversion(
                locationCategoryId => locationCategoryId.Value,
                dbId => LocationCategoryId.Of(dbId));

            builder.Property(lc => lc.Name)
                .HasColumnName(nameof(LocationCategory.Name))
                .HasConversion(
                name => name.Value,
                dbName => Name.Of(dbName));

            builder.Property(lc => lc.Description)
                .HasColumnName(nameof(LocationCategory.Description))
                .HasConversion(
                description => description.Value,
                dbDescription => Description.Of(dbDescription)
                );
        }
        public void ConfigureLocationRelation(EntityTypeBuilder<LocationCategory> builder)
        {
            builder.OwnsMany(lc => lc.LocationIds, lid =>
            {
                lid.ToTable("LocationIds");

                lid.WithOwner().HasForeignKey("LocationCategoryId");

                lid.HasKey("Id");

                lid.Property(l => l.Value)
                    .HasColumnName("LocationId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(LocationCategory.LocationIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
