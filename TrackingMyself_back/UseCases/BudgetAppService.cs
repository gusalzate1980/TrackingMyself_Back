using Application.Mappers;
using Dto.Api;
using Dto.Budget;
using Repository.BudgetRepository;
using Services;
using TrackingMyself.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UseCases
{
    public class BudgetAppService: IBudgetAppService
    {
        public BudgetDomain Budget { get; set; }
        private TimeDomain? _timeDomain;

        private readonly ISingletonDomainAppService _singleton;
        private readonly IBudgetRepository _budgetRepository;

        public BudgetAppService(ISingletonDomainAppService singleton,
                                IBudgetRepository budgetRepository)
        {
            _singleton = singleton;
            _budgetRepository = budgetRepository;
        }
        public ApiResponseDto<WildCardDto> CreateBudget(CreateBudgetDto createBudgetDto)
        {
            ApiResponseDto<WildCardDto> response = new ApiResponseDto<WildCardDto>();

            Budget = createBudgetDto.ToDomain();

            if(GivenTimeExistis(Budget.Time))
            {
                Budget.Time.Id = _timeDomain.Id;

                var budgetDomainService = new BudgetDomainService();
                List<BudgetDomain> currentAndFutureBdgets = _budgetRepository.GetCurrentAndFutureBudgets();

                var result = budgetDomainService.CreateBudget(Budget, currentAndFutureBdgets);

                if (result.IsValid)
                {
                    _budgetRepository.AddBudget(Budget);
                    response.ExecutionOk = true;
                    return response;
                }
                else
                {
                    response.ExecutionOk = false;
                    response.Errors = new List<ApiErrorDto>();
                    foreach (var error in budgetDomainService.Errors)
                    {
                        error.ErrorDetail.ForEach(errorDetail =>
                        {
                            response.Errors.Add(new ApiErrorDto()
                            {
                                Error = errorDetail,
                                ErrorType = ApiErrorEnum.DOMAIN,
                                Where = $"{error.ObjectName}.{error.MethodName}"
                            });
                        });
                    }

                    return response;
                }
            }
            else
            {
                response.ExecutionOk = false;
                response.Errors = new List<ApiErrorDto>
                {
                    new ApiErrorDto()
                    {
                        Error = "The specified time domain does not exist.",
                        ErrorType = ApiErrorEnum.APPLICATION,
                        Where = $"{nameof(BudgetAppService)}.{nameof(CreateBudget)}"
                    }
                };

                return response;
            }
        }

        #region private methods
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
        #endregion
    }
}
