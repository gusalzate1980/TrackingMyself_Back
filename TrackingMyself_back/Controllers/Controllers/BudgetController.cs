using Dto.Budget;
using Microsoft.AspNetCore.Mvc;
using UseCases;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetAppService _budgetAppService;
        private readonly ISingletonDomainAppService _singletonDomainAppService;

        public BudgetController(IBudgetAppService budgetAppService, 
                                ISingletonDomainAppService singletonDomainAppService)
        {
            _budgetAppService = budgetAppService;
            _singletonDomainAppService = singletonDomainAppService;
        }


        [HttpPost]
        public IActionResult CreateBudget([FromBody] CreateBudgetDto dto)
        {
            var x = _singletonDomainAppService.TimeDomainList();
            _budgetAppService.CreateBudget(dto);
            
            return Ok();
        }

    }
}
