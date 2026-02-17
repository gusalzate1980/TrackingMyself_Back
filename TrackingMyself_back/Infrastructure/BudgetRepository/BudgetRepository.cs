using ApplicationMappers;
using Entity;
using EntityFramework.Data;
using EntityFramework.Models;
using TrackingMyself.Domain.Entities;

namespace Repository.BudgetRepository
{
    public class BudgetRepository : IBudgetRepository
    {
        public void AddBudget(BudgetDomain budget)
        {
            throw new NotImplementedException();
        }

        public List<BudgetDomain> GetCurrentAndFutureBudgets()
        {
            TrackingMyselfDbContext context = new TrackingMyselfDbContext();

            List<Budget> budgets = context.Budgets.Where(b=>b.IdTimeNavigation.TimeTense  == (int)TimeTenseEnum.PRESENT
                                                                        ||
                                                                     b.IdTimeNavigation.TimeTense == (int)TimeTenseEnum.FUTURE).ToList();

            List<BudgetDomain> budgetDomains = new List<BudgetDomain>();

            foreach (var budget in budgets)
            {
                budgetDomains.Add(budget.ToDomain());
            }

            return budgetDomains;
        }
    }
}
