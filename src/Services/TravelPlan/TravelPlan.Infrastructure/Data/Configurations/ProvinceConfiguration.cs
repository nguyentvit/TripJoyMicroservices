namespace TravelPlan.Infrastructure.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            ConfigureProvinceTable(builder);
            ConfigurePlanRelation(builder);
        }
        private void ConfigureProvinceTable(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                provinceId => provinceId.Value,
                dbId => ProvinceId.Of(dbId)
                );

            builder.Property(p => p.Name)
                .HasColumnName(nameof(Province.Name))
                .HasConversion(
                name => name.Value,
                dbName => ProvinceName.Of(dbName)
                );
        }
        private void ConfigurePlanRelation(EntityTypeBuilder<Province> builder)
        {
            builder.OwnsMany(p => p.PlanIds, pi =>
            {
                pi.ToTable("PlanIds");

                pi.WithOwner().HasForeignKey("ProvinceId");

                pi.HasKey("Id");

                pi.Property(p => p.Value)
                    .HasColumnName("PlanId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Province.PlanIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
