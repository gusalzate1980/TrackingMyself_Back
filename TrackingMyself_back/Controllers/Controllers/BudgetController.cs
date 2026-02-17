using Dto.Api;
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
        public IActionResult CreateBudget([FromBody] ApiRequestDto<CreateBudgetDto> request)
        {
            var response = _budgetAppService.CreateBudget(request.RequestValue);
            
            if (response.ExecutionOk)
                return Ok(response);

            return BadRequest(response);
        }

    }
}
