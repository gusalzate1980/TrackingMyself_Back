using ApplicationMappers;
using EntityFramework.Data;
using TrackingMyself.Domain.Entities;

namespace Repository.Time
{
    public class TimeRepository : ITimeRepository
    {
        public List<TimeDomain> GetAllTimes()
        {
            TrackingMyselfDbContext context = new TrackingMyselfDbContext();

            List<TimeDomain> times = new List<TimeDomain>();

            foreach (var time in context.Times.ToList())
            {
                times.Add(time.ToDomain());
            }

            return times;
        }
    }
}
