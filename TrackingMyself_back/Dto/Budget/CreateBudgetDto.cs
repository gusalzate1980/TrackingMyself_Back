namespace Dto.Budget
{
    public class CreateBudgetDto
    {
        public int Income { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }  
        public string TimeTense { get; set; }

    }
}