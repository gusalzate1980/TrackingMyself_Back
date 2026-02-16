using Application.Mappers;
using Dto.Budget;
using Services;
using TrackingMyself.Domain.Entities;

namespace UseCases
{
    public class BudgetAppService: IBudgetAppService
    {
        public BudgetDomain Budget { get; set; }
        private TimeDomain _timeDomain;

        private readonly ISingletonDomainAppService _singleton;

        public BudgetAppService(ISingletonDomainAppService singleton)
        {
            _singleton = singleton;
        }
        public void CreateBudget(CreateBudgetDto createBudgetDto)
        {
            Budget = createBudgetDto.ToDomain();

            if(GivenTimeExistis(Budget.Time))
            {
                var budgetDomainService = new BudgetDomainService();

                var result = budgetDomainService.CreateBudget(Budget, new List<BudgetDomain>());
                if (result.IsValid)
                {

                }
                else
                {
                    // Handle errors, e.g., log them or return them to the caller
                    foreach (var error in budgetDomainService.Errors)
                    {
                        Console.WriteLine($"Error in {error.ObjectName}.{error.MethodName}: {string.Join(", ", error.ErrorDetail)}");
                    }
                }
            }
            else
            {

            }
        }

        private bool GivenTimeExistis(TimeDomain timeDomain)
        {
            _timeDomain = _singleton.TimeDomainList().FirstOrDefault(t =>   t.Year      ==  timeDomain.Year
                                                                            && t.Month  ==  timeDomain.Month);
            
            if (_timeDomain != null)
            {
                return true;
            }

            return false;
        }
    }
}
