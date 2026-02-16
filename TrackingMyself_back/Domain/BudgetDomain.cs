using System.Timers;

namespace TrackingMyself.Domain.Entities
{
    public class BudgetDomain
    {
        public int Id { get; set; }


        public int Income { get; set; }

        public int Available { get; set; }

        public string Description { get; set; }

        public virtual TimeDomain Time { get; set; }

        public bool IsValid { set; get; }
    }
}