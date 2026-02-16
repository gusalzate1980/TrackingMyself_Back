using Dto.Budget;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases
{
    public interface IBudgetAppService
    {
        void CreateBudget(CreateBudgetDto createBudgetDto);
    }
}
