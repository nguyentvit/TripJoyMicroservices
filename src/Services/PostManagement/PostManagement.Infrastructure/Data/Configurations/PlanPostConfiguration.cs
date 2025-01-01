using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostManagement.Infrastructure.Data.Configurations
{
    public class PlanPostConfiguration : IEntityTypeConfiguration<PlanPost>
    {
        public void Configure(EntityTypeBuilder<PlanPost> builder)
        {
            builder.HasBaseType<Post>();
            ConfigurePlanPostTable(builder);
            ConfigurePlanPostPlanPostTable(builder);
        }
        private void ConfigurePlanPostTable(EntityTypeBuilder<PlanPost> builder)
        {
            builder.Property(pp => pp.PlanId)
                .HasConversion(
                    planId => planId.Value,
                    dbPlanId => PlanId.Of(dbPlanId)
                );

            builder.Property(pp => pp.PlanStartDate)
                .HasConversion(
                    date => date.Value,
                    dbDate => Date.Of(dbDate)
                );

            builder.Property(pp => pp.PlanEndDate)
                .HasConversion(
                    date => date.Value,
                    dbDate => Date.Of(dbDate)
                );

            builder.Property(pp => pp.Budget)
                .HasConversion(
                    budget => budget.Value,
                    dbBudget => Money.Of(dbBudget)
                );


            builder.ComplexProperty(pp => pp.ProvinceStart, provinceBuilder =>
            {
                provinceBuilder.Property(p => p.ProvinceId)
                    .HasColumnName("ProvinceIdStart");

                provinceBuilder.Property(p => p.ProvinceName)
                    .HasColumnName("ProvinceNameStart");
            });

            builder.ComplexProperty(pp => pp.ProvinceEnd, provinceBuilder =>
            {
                provinceBuilder.Property(p => p.ProvinceId)
                    .HasColumnName("ProvinceIdEnd");

                provinceBuilder.Property(p => p.ProvinceName)
                    .HasColumnName("ProvinceNameEnd");
            });

            builder.Property(pp => pp.Vehicle)
                .HasConversion(
                    vehicle => vehicle.ToString(),
                    dbVehicle => (PlanVehicle)Enum.Parse(typeof(PlanVehicle), dbVehicle)
                );
        }
        private void ConfigurePlanPostPlanPostTable(EntityTypeBuilder<PlanPost> builder)
        {
            builder.OwnsMany(pp => pp.PostPlanLocations, ppls =>
            {
                ppls.ToTable("PostPlanLocation");
                ppls.WithOwner().HasForeignKey("PostId");
                ppls.HasKey("Id", "PostId");

                ppls.Property(ppl => ppl.Id)
                    .HasColumnName("PostPlanLocationId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        dbId => PostPlanLocationId.Of(dbId)
                    );

                ppls.Property(ppl => ppl.LocationId)
                    .HasConversion(
                        locationId => locationId.Value,
                        dbLocationId => LocationId.Of(dbLocationId)
                    );

                ppls.OwnsOne(ppl => ppl.Coordinates, coordinatesBuilder =>
                {
                    coordinatesBuilder.Property(c => c.Latitude)
                        .HasColumnName(nameof(Coordinates.Latitude));

                    coordinatesBuilder.Property(c => c.Longitude)
                        .HasColumnName(nameof(Coordinates.Longitude));
                });

                ppls.Property(ppl => ppl.Order)
                    .HasConversion(
                        order => order.Value,
                        dbOrder => Order.Of(dbOrder)
                    );

                ppls.Property(ppl => ppl.EstimatedStartDate)
                    .HasConversion(
                        date => date.Value,
                        dbDate => Date.Of(dbDate)
                    );

                ppls.Property(ppl => ppl.Name)
                    .HasConversion(
                        name => name.Value,
                        dbName => LocationName.Of(dbName)
                    );

                ppls.Property(ppl => ppl.Address)
                    .HasConversion(
                        address => address.Value,
                        dbAddress => LocationAddress.Of(dbAddress)
                    );
            });
        }
    }
}
