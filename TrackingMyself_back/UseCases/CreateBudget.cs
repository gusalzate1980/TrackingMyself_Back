using Dto.Budget;
using Mappers;
using Services;
using TrackingMyself.Domain.Entities;

namespace UseCases
{
    public class CreateBudget
    {
        public Budget Budget { get; set; }
        public void Execute(CreateBudgetDto createBudgetDto)
        {
            Budget = createBudgetDto.ToDomain();
            var budgetService = new BudgetService();

            var currentAndFutureBudgets = new List<Budget>(); // This should be fetched from the database or repository
            var time1 = new Time { Id = 1, Year = 2025, Month = 12, TimeTense = Entity.TimeTenseEnum.PAST };
            var time2 = new Time { Id = 2, Year = 2026, Month = 2, TimeTense = Entity.TimeTenseEnum.PRESENT };
            var time3 = new Time { Id = 3, Year = 2026, Month = 3, TimeTense = Entity.TimeTenseEnum.FUTURE };

            currentAndFutureBudgets.Add(new Budget { Id = 1, Time = time1, Income = 1000, Available = 0 });
            currentAndFutureBudgets.Add(new Budget { Id = 2, Time = time2, Income = 1500, Available = 0 });
            currentAndFutureBudgets.Add(new Budget { Id = 3, Time = time3, Income = 2000, Available = 2000 });
        
            var result = budgetService.CreateBudget(Budget, currentAndFutureBudgets);
            if (result.IsValid)
            {
                
            }
            else
            {
                // Handle errors, e.g., log them or return them to the caller
                foreach (var error in budgetService.Errors)
                {
                    Console.WriteLine($"Error in {error.ObjectName}.{error.MethodName}: {string.Join(", ", error.ErrorDetail)}");
                }
            }
        }
    }
}
