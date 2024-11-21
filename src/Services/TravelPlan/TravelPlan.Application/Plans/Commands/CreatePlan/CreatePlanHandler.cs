﻿namespace TravelPlan.Application.Plans.Commands.CreatePlan
{
    public class CreatePlanHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<CreatePlanCommand, CreatePlanResult>
    {
        public async Task<CreatePlanResult> Handle(CreatePlanCommand command, CancellationToken cancellationToken)
        {
            var provinceStartId = ProvinceId.Of(command.Plan.ProvinceStartId);
            var provinceEndId = ProvinceId.Of(command.Plan.ProvinceEndId);

            var provinceStart = await dbContext.Provinces.FindAsync([provinceStartId], cancellationToken);

            if (provinceStart == null)
                throw new ProvinceNotFoundException(provinceStartId.Value);

            var provinceEnd = await dbContext.Provinces.FindAsync([provinceEndId], cancellationToken);

            if (provinceEnd == null)
                throw new ProvinceNotFoundException(provinceEndId.Value);

            var newPlan = CreateNewPlan(command);

            dbContext.Plans.Add(newPlan);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePlanResult(newPlan.Id.Value);
        }
        private Plan CreateNewPlan(CreatePlanCommand command)
        {
            return Plan.Of(
                title: Title.Of(command.Plan.Title),
                avatar: (command.Plan.Avatar != null) ? Image.Of(command.Plan.Avatar) : null,
                startDate: Date.Of(command.Plan.StartDate),
                endDate: Date.Of(command.Plan.EndDate),
                estimatedBudget: Money.Of(command.Plan.EstimatedBudget),
                method: command.Plan.Method,
                provinceStartId: ProvinceId.Of(command.Plan.ProvinceStartId),
                provinceEndId: ProvinceId.Of(command.Plan.ProvinceEndId),
                userId: UserId.Of(command.UserId),
                vehicle: command.Plan.Vehicle
                );
        }
    }
}
