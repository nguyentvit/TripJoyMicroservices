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
            builder.OwnsMany(pl => pl.Expenses, ple =>
            {
                ple.ToTable("PlanLocationExpense");
                ple.WithOwner().HasForeignKey("PlanLocationId");
                ple.HasKey("Id", "PlanLocationId");

                ple.Property(pe => pe.Id)
                    .HasColumnName("PlanLocationExpenseId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    dbId => PlanLocationExpenseId.Of(dbId)
                    );

                ple.Property(pe => pe.Title)
                    .HasColumnName(nameof(PlanLocationExpense.Title))
                    .HasConversion(
                    title => title.Value,
                    dbTitle => Title.Of(dbTitle)
                    );

                ple.Property(pe => pe.Note)
                    .HasColumnName(nameof(PlanLocationExpense.Note))
                    .HasConversion(
                    note => note.Value,
                    dbNote => Note.Of(dbNote)
                    );

                ple.Property(pe => pe.Amount)
                    .HasColumnName(nameof(PlanLocationExpense.Amount))
                    .HasConversion(
                    amount => amount.Value,
                    dbAmount => Money.Of(dbAmount)
                    );
            });
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
