namespace TravelPlan.Infrastructure.Data.Configurations
{
    public class PlanLocationConfiguration : IEntityTypeConfiguration<PlanLocation>
    {
        public void Configure(EntityTypeBuilder<PlanLocation> builder)
        {
            ConfigurePlanLocationTable(builder);
            ConfigurePlanLocationPlanLocationImageTable(builder);
            ConfigurePlanLocationPlanLocationExpenseTable(builder);
            ConfigurePlanRelation(builder);
        }
        private void ConfigurePlanLocationTable(EntityTypeBuilder<PlanLocation> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.Id)
                .HasConversion(
                planLocationId => planLocationId.Value,
                dbId => PlanLocationId.Of(dbId)
                );

            builder.Property(pl => pl.LocationId)
                .HasColumnName(nameof(PlanLocation.LocationId))
                .HasConversion(
                locationId => locationId.Value,
                dbId => LocationId.Of(dbId)
                );

            builder.Property(pl => pl.Note)
                .HasColumnName(nameof(PlanLocation.Note))
                .HasConversion(
                note => note.Value,
                dbNote => Note.Of(dbNote)
                );

            builder.Property(pl => pl.Order)
                .HasColumnName(nameof(PlanLocation.Order))
                .HasConversion(
                order => order.Value,
                dbOrder => PlanLocationOrder.Of(dbOrder)
                );

            builder.Property(pl => pl.Status)
                .HasColumnName(nameof(PlanLocation.Status))
                .HasConversion(
                status => status.ToString(),
                dbStatus => (PlanLocationStatus)Enum.Parse(typeof(PlanLocationStatus), dbStatus)
                );

            builder.OwnsOne(p => p.PayerId, payerIdBuilder =>
            {
                payerIdBuilder.Property(p => p.Value)
                    .HasColumnName(nameof(PlanLocation.PayerId));
            });

            builder.OwnsOne(p => p.Amount, amountBuilder =>
            {
                amountBuilder.Property(a => a.Value)
                    .HasColumnName(nameof(PlanLocation.Amount));
            });

            builder.ComplexProperty(pl => pl.Coordinates, coordinatesBuilder =>
            {
                coordinatesBuilder.Property(c => c.Latitude)
                    .HasColumnName(nameof(Coordinates.Latitude));

                coordinatesBuilder.Property(c => c.Longitude)
                    .HasColumnName(nameof(Coordinates.Longitude));
            });

        }
        private void ConfigurePlanLocationPlanLocationImageTable(EntityTypeBuilder<PlanLocation> builder)
        {
            builder.OwnsMany(pl => pl.Images, pli =>
            {
                pli.ToTable("PlanLocationImage");

                pli.WithOwner().HasForeignKey("PlanLocationId");

                pli.HasKey("Id", "PlanLocationId");

                pli.Property(i => i.Id)
                    .HasColumnName("PlanLocationImageId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    dbId => PlanLocationImageId.Of(dbId));

                pli.Property(i => i.UserIdUploaded)
                    .HasColumnName(nameof(PlanLocationImage.UserIdUploaded))
                    .HasConversion(
                    userId => userId.Value,
                    dbUserId => UserId.Of(dbUserId)
                    );

                pli.Property(i => i.Image)
                    .HasColumnName(nameof(PlanLocationImage.Image))
                    .HasConversion(
                    image => image.Url,
                    dbImage => Image.Of(dbImage)
                    );

                pli.Property(i => i.Title)
                    .HasColumnName(nameof(PlanLocationImage.Title))
                    .HasConversion(
                    title => title.Value,
                    dbTitle => Title.Of(dbTitle)
                    );

            });
        }
        private void ConfigurePlanLocationPlanLocationExpenseTable(EntityTypeBuilder<PlanLocation> builder)
        {
            builder.OwnsMany(pl => pl.PlanLocationUserSpenders, us =>
            {
                us.ToTable("PlanLocationUserSpender");
                us.WithOwner().HasForeignKey("PlanLocationId");
                us.HasKey("Id", "PlanLocationId");

                us.Property(u => u.Id)
                    .HasColumnName("PlanLocationUserSpenderId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => PlanLocationUserSpenderId.Of(value)
                    );

                us.Property(u => u.UserSpenderId)
                    .HasColumnName("UserSpenderId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserId.Of(value)
                    );
            });

            builder.Metadata.FindNavigation(nameof(PlanLocation.PlanLocationUserSpenders))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigurePlanRelation(EntityTypeBuilder<PlanLocation> builder)
        {
            builder.Property(pl => pl.PlanId)
                .HasConversion(
                id => id.Value,
                dbId => PlanId.Of(dbId)
                );
        }
    }
}
