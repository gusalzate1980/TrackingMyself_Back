using Entity;
using EntityFramework.Models;
using TrackingMyself.Domain.Entities;

namespace ApplicationMappers
{
    public static class FromInfrastructureToDomain
    {
        public static TimeDomain ToDomain(this Time time)
        {
            return new TimeDomain()
            {
                Id = time.Id,
                Year = time.Year,
                Month = time.Month,
                TimeTense = (TimeTenseEnum)time.TimeTense
            };
        }

        public static BudgetDomain ToDomain(this Budget budget)
        {
            return new BudgetDomain()
            {
                Id = budget.Id,
                Income = budget.Income,
                Available = budget.Available,
                Description = budget.Description,
                Time = budget.IdTimeNavigation.ToDomain()
            };
        }
    }
}