using Dto.Budget;
using Entity;
using TrackingMyself.Domain.Entities;

namespace Application.Mappers
{
    public static class FromDtoToDomain
    {
        public static BudgetDomain ToDomain(this CreateBudgetDto dto)
        {
            TimeTenseEnum timeTenseEnum = TimeTenseEnum.NOT_DEFINED;

            try
            {
                timeTenseEnum = Enum.Parse<TimeTenseEnum>(dto.TimeTense);
            }
            catch(Exception e)
            {
                
            }
            return new BudgetDomain()
            {
                Income = dto.Income,
                Description = dto.Description,
                Time = new TimeDomain()
                {
                    Year = dto.Year,
                    Month = dto.Month,
                    TimeTense = timeTenseEnum
                }
            };
        }
    }
}