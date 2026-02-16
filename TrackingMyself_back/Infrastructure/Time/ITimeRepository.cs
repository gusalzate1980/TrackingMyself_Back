using TrackingMyself.Domain.Entities;

namespace Repository.Time
{
    public interface ITimeRepository
    {
        public List<TimeDomain> GetAllTimes();
    }
}
