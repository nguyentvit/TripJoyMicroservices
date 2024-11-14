namespace TravelPlan.Infrastructure.Data.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            ConfigurePlanTable(builder);
            ConfigurePlanPlanMemberTable(builder);
            ConfigurePlanPlanInvitationTable(builder);
            ConfigurePlanPlanVehicleTable(builder);
            ConfigurePlanLocationRelation(builder);
        }
        private void ConfigurePlanTable(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                planId => planId.Value,
                dbId => PlanId.Of(dbId)
                );

            builder.Property(p => p.Title)
                .HasColumnName(nameof(Plan.Title))
                .HasConversion(
                title => title.Value,
                dbTitle => Title.Of(dbTitle));

            builder.OwnsOne(p => p.Avatar, avatarBuilder =>
            {
                avatarBuilder.Property(a => a.Url)
                    .HasColumnName(nameof(Plan.Avatar));
            });

            builder.Property(p => p.StartDate)
                .HasColumnName(nameof(Plan.StartDate))
                .HasConversion(
                startDate => startDate.Value,
                dbStartDate => Date.Of(dbStartDate)
                );

            builder.Property(p => p.EndDate)
                .HasColumnName(nameof(Plan.EndDate))
                .HasConversion(
                endDate => endDate.Value,
                dbEndDate => Date.Of(dbEndDate)
                );

            builder.Property(p => p.Note)
                .HasColumnName(nameof(Plan.Note))
                .HasConversion(
                note => note.Value,
                dbNote => Note.Of(dbNote)
                );

            builder.Property(p => p.EstimatedBudget)
                .HasColumnName(nameof(Plan.EstimatedBudget))
                .HasConversion(
                budget => budget.Value,
                dbBudget => Money.Of(dbBudget)
                );

            builder.Property(p => p.Visibility)
                .HasColumnName(nameof(Plan.Visibility))
                .HasConversion(
                visibility => visibility.ToString(),
                dbVisibility => (Visibility)Enum.Parse(typeof(Visibility), dbVisibility)
                );

            builder.Property(p => p.Status)
                .HasColumnName(nameof(Plan.Status))
                .HasConversion(
                status => status.ToString(),
                dbStatus => (PlanStatus)Enum.Parse(typeof(PlanStatus), dbStatus)
                );

            builder.Property(p => p.Method)
                .HasColumnName(nameof(Plan.Method))
                .HasConversion(
                method => method.ToString(),
                dbMethod => (CreationMethod)Enum.Parse(typeof(CreationMethod), dbMethod)
                );
        }
        private void ConfigurePlanPlanMemberTable(EntityTypeBuilder<Plan> builder)
        {
            builder.OwnsMany(p => p.Members, pm =>
            {
                pm.ToTable("PlanMember");
                pm.WithOwner().HasForeignKey("PlanId");
                pm.HasKey("Id", "PlanId");

                pm.Property(m => m.Id)
                    .HasColumnName("PlanMemberId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    dbId => PlanMemberId.Of(dbId)
                    );

                pm.Property(m => m.Role)
                    .HasColumnName(nameof(PlanMember.Role))
                    .HasConversion(
                    role => role.ToString(),
                    dbRole => (MemberRole)Enum.Parse(typeof(MemberRole), dbRole)
                    );

                pm.Property(m => m.MemberId)
                    .HasColumnName(nameof(PlanMember.MemberId))
                    .HasConversion(
                    memberId => memberId.Value,
                    dbId => UserId.Of(dbId)
                    );
            });
        }
        private void ConfigurePlanPlanInvitationTable(EntityTypeBuilder<Plan> builder)
        {
            builder.OwnsMany(p => p.Invitations, pi =>
            {
                pi.ToTable("PlanInvitation");
                pi.WithOwner().HasForeignKey("PlanId");
                pi.HasKey("Id", "PlanId");

                pi.Property(i => i.Id)
                    .HasColumnName("PlanInvitationId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    dbId => PlanInvitationId.Of(dbId)
                    );

                pi.Property(i => i.InviterId)
                    .HasColumnName(nameof(PlanInvitation.InviterId))
                    .HasConversion(
                    inviterId => inviterId.Value,
                    dbInviterId => UserId.Of(dbInviterId)
                    );

                pi.Property(i => i.InviteeId)
                    .HasColumnName(nameof(PlanInvitation.InviteeId))
                    .HasConversion(
                    inviteeId => inviteeId.Value,
                    dbInviteeId => UserId.Of(dbInviteeId)
                    );
            });
        }
        private void ConfigurePlanPlanVehicleTable(EntityTypeBuilder<Plan> builder)
        {
            builder.OwnsMany(p => p.Vehicles, pv =>
            {
                pv.ToTable("PlanVehicle");
                pv.WithOwner().HasForeignKey("PlanId");
                pv.HasKey("Id", "PlanId");

                pv.Property(v => v.Id)
                    .HasColumnName("PlanVehicleId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    dbId => PlanVehicleId.Of(dbId)
                    );

                pv.Property(v => v.Vehicle)
                    .HasColumnName(nameof(PlanVehicle.Vehicle))
                    .HasConversion(
                    vehicle => vehicle.ToString(),
                    dbVehicle => (Vehicle)Enum.Parse(typeof(Vehicle), dbVehicle)
                    );

            });
        }
        private void ConfigurePlanLocationRelation(EntityTypeBuilder<Plan> builder)
        {
            builder.OwnsMany(p => p.PlanLocationIds, pli =>
            {
                pli.ToTable("PlanLocationIds");

                pli.WithOwner().HasForeignKey("PlanId");

                pli.HasKey("Id");

                pli.Property(pl => pl.Value)
                    .HasColumnName("PlanLocationId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Plan.PlanLocationIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
