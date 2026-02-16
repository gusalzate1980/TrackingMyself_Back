using Dto.Budget;
using Entity;
using TrackingMyself.Domain.Entities;

namespace Application.Mappers
{
    public static class FromDtoToDomain
    {
        public static Budget ToDomain(this CreateBudgetDto dto)
        {
            return new Budget()
            {
                Income = dto.Income,
                Decription = dto.Description,
                Time = new Time()
                {
                    Year = dto.Year,
                    Month = dto.Month,
                    TimeTense = Enum.Parse<TimeTenseEnum>(dto.TimeTense)
                }
            };
        }
    }
}