using System.Timers;

namespace TrackingMyself.Domain.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        public int IdTime { get; set; }

        public int Income { get; set; }

        public int Available { get; set; }

        public string? Decription { get; set; }

        // Relación con la entidad Time (si existe la tabla referenciada por la FK)
        public virtual Time? Time { get; set; }
    }
}