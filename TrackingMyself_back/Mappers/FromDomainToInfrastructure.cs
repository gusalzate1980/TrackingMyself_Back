using EntityFramework.Models;
using TrackingMyself.Domain.Entities;

namespace Application.Mappers
{
    public static class FromDomainToInfrastructure
    {
        public static Budget ToInfrastructure(this BudgetDomain budget)
        {
            return new Budget()
            {
                Income = budget.Income,
                Description = budget.Description,
                IdTime = budget.Time.Id,
                Available = budget.Available
            };
        }
    }
}