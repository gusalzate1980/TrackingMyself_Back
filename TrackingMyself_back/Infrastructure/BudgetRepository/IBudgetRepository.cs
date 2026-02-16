using TrackingMyself.Domain.Entities;

namespace Repository.BudgetRepository
{
    public interface IBudgetRepository
    {
        public void AddBudget(BudgetDomain budget);
    }
}
