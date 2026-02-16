using System.Timers;

namespace TrackingMyself.Domain.Entities
{
    public class Budget
    {
        public int Id { get; set; }


        public int Income { get; set; }

        public int Available { get; set; }

        public string? Decription { get; set; }

        public virtual Time Time { get; set; }

        public bool IsValid { set; get; }
    }
}