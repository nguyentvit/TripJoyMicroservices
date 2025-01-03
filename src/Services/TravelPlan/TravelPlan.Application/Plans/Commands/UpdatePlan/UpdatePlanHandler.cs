﻿namespace TravelPlan.Application.Plans.Commands.UpdatePlan
{
    public class UpdatePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<UpdatePlanCommand, UpdatePlanResult>
    {
        public async Task<UpdatePlanResult> Handle(UpdatePlanCommand command, CancellationToken cancellationToken)
        {
            var planId = PlanId.Of(command.PlanId);

            var plan = await dbContext.Plans.FindAsync([planId], cancellationToken);
            
            if (plan == null)
                throw new PlanNotFoundException(planId.Value);
            var provinceStartId = ProvinceId.Of(command.Plan.ProvinceStartId);
            var provinceStart = await dbContext.Provinces.FindAsync([provinceStartId], cancellationToken);
            if (provinceStart == null)
                throw new ProvinceNotFoundException(provinceStartId.Value);

            var provinceEndId = ProvinceId.Of(command.Plan.ProvinceEndId);
            var provinceEnd = await dbContext.Provinces.FindAsync([provinceEndId], cancellationToken);
            if (provinceEnd == null)
                throw new ProvinceNotFoundException(provinceEndId.Value);

            var planLocations = await dbContext.PlanLocations.Where(pl => pl.PlanId == planId).OrderBy(pl => pl.Order).ToListAsync(cancellationToken);

            foreach (var planLocation in planLocations)
            {
                if (planLocation.EstimatedStartDate.Value.Date < command.Plan.StartDate.Date || planLocation.EstimatedStartDate.Value.Date > command.Plan.EndDate.Date)
                    throw new Exception($"There are have plan location in old estimated time, {planLocation.Coordinates.Longitude}:{planLocation.Coordinates.Latitude}");
            }
            


            UpdatePlan(plan, command);
            dbContext.Plans.Update(plan);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePlanResult(true);

        }
        private void UpdatePlan(Plan plan, UpdatePlanCommand command)
        {
            plan.UpdatePlan(
                title: Title.Of(command.Plan.Title),
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                provinceStartId: ProvinceId.Of(command.Plan.ProvinceStartId),
                provinceEndId: ProvinceId.Of(command.Plan.ProvinceEndId),
                vehicle: command.Plan.Vehicle,
                userId: UserId.Of(command.UserId),
                avatar: (command.Plan.Avatar != null) ? FileImg.Of(command.Plan.Avatar) : null
                );
        }
    }
}
