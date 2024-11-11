using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationAttraction.Infrastructure.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            ConfigureLocationTable(builder);
            ConfigureLocationImageTable(builder);
            ConfigureLocationCategoryRelation(builder);
            ConfigureLocationRatingTable(builder);
        }
        public void ConfigureLocationTable(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasConversion(
                locationId => locationId.Value,
                dbId => LocationId.Of(dbId)
                );

            builder.Property(l => l.Name)
                .HasColumnName(nameof(Location.Name))
                .HasConversion(
                name => name.Value,
                dbName => Name.Of(dbName));

            builder.OwnsOne(l => l.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Value)
                    .HasColumnName(nameof(Location.Address))
                    .HasMaxLength(100);
            });

            builder.ComplexProperty(l => l.Coordinates, coordinatesBuilder =>
            {
                coordinatesBuilder.Property(c => c.Latitude)
                    .HasColumnName(nameof(Coordinates.Latitude));

                coordinatesBuilder.Property(c => c.Longitude)
                    .HasColumnName(nameof(Coordinates.Longitude));
            });

            builder.ComplexProperty(l => l.AverageRating, averageRatingBuilder =>
            {
                averageRatingBuilder.Property(a => a.NumRatings)
                    .HasColumnName(nameof(AverageRating.NumRatings));

                averageRatingBuilder.Property(a => a.Value)
                    .HasColumnName(nameof(AverageRating.Value));
            });

        }
        public void ConfigureLocationImageTable(EntityTypeBuilder<Location> builder)
        {
            builder.OwnsMany(l => l.Images, img =>
            {
                img.ToTable("LocationImage");
                img.WithOwner().HasForeignKey("LocationId");
                img.HasKey("Id", "LocationId");

                img.Property(img => img.Id)
                    .HasColumnName("LocationImageId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => ImageId.Of(dbId)
                    );

                img.Property(img => img.Url)
                    .HasColumnName(nameof(Image.Url));
            });
        }
        public void ConfigureLocationRatingTable(EntityTypeBuilder<Location> builder)
        {
            builder.OwnsMany(l => l.Ratings, rt =>
            {
                rt.ToTable("LocationRatings");
                rt.WithOwner().HasForeignKey("LocationId");

                rt.Property(rt => rt.Id)
                    .HasColumnName("LocationRatingId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => RatingId.Of(dbId));

                rt.Property(rt => rt.UserId)
                    .HasColumnName(nameof(Rating.UserId))
                    .HasConversion(
                        userId => userId.Value,
                        dbId => UserId.Of(dbId)
                    );

                rt.Property(rt => rt.Value)
                    .HasColumnName(nameof(Rating.Value));
            }); 
        }
        public void ConfigureLocationCategoryRelation(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.LocationCategoryId)
                .HasConversion(
                id => id.Value,
                dbId => LocationCategoryId.Of(dbId)
                );
        }
    }
}
