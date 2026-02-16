using Entity;

namespace TrackingMyself.Domain.Entities
{
    public class Time
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public TimeTenseEnum TimeTense { get; set; }

        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

        public string TimeTenseDescription
        {
            get
            {
                return TimeTense switch
                {
                    TimeTenseEnum.PAST => "Past",
                    TimeTenseEnum.PRESENT => "Present",
                    TimeTenseEnum.FUTURE => "Future",
                    _ => "Unknown"
                };
            }
        }
    }
}