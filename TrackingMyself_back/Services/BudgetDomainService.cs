using Entity;
using TrackingMyself.Domain.Entities;

namespace Services
{
    public class BudgetDomainService : EntityServiceBase
    {
       
        public BudgetDomain CreateBudget(BudgetDomain budget, List<BudgetDomain> currentAndfutureBudgets)
        {
            List<string> errors = new List<string>();

            if (TimeTenseIsInPast(budget.Time.TimeTense))
            {
                errors.Add("Budget cannot be created for past tenses.");
            }

            if (ThereIsBudgetInSameCurrentTimeTense(currentAndfutureBudgets, budget.Time))
            {
                errors.Add("There is already a budget in the current period.");
            }

            if (ThereIsBudgetInSameFutureTimeTense(currentAndfutureBudgets, budget.Time))
            {
                errors.Add("There is already a budget in the same future period.");
            }

            if (!IncomeIsGreaterThanZero(budget.Income))
            {
                errors.Add("Income must be greater than zero.");
            }
            else
            {
                budget.Available = budget.Income;
            }

            if (errors.Any())
            {
                AddError(new DomainError()
                {
                    ErrorDetail = errors,
                    ObjectName = nameof(BudgetDomainService),
                    MethodName = nameof(CreateBudget)   
                });
                budget.IsValid = false;
            }
            else
                budget.IsValid = true;

            return budget;
        }

        #region Business Rules
        private bool TimeTenseIsInPast(TimeTenseEnum timeTense)
        {
            return timeTense.Equals(TimeTenseEnum.PAST);
        }

        private bool ThereIsBudgetInSameCurrentTimeTense(List<BudgetDomain> currentAndfutureBudgets, TimeDomain budgetTime)
        {
            return currentAndfutureBudgets.Any(b => b.Time.TimeTense.Equals(TimeTenseEnum.PRESENT) 
                                                    && b.Time.Month == budgetTime.Month && b.Time.Year == budgetTime.Year);
        }

        private bool ThereIsBudgetInSameFutureTimeTense(List<BudgetDomain> currentAndfutureBudgets, TimeDomain budgetTime)
        {
            return currentAndfutureBudgets.Any(b => b.Time.TimeTense.Equals(TimeTenseEnum.FUTURE) && b.Time.TimeTense.Equals(TimeTenseEnum.FUTURE)
                                                     && b.Time.Month == budgetTime.Month && b.Time.Year == budgetTime.Year);
        }

        private bool IncomeIsGreaterThanZero(decimal income)
        {
            return income > 0;
        }
        #endregion
    }
}